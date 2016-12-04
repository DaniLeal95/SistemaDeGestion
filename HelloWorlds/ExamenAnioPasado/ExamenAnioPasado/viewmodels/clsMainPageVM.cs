using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using ExamenAnioPasado.viewModels;

namespace ExamenAnioPasado
{
    public class clsMainPageVM:clsVMBase
    {
        private Trilogia _trilogiaSeleccionada;
        private ObservableCollection<Trilogia> _listatrilogia;
        private Pelicula _peliculaSeleccionada;
        private ObservableCollection<Pelicula> _listapelicula;
        private Personaje _personajeSeleccionado;

        private ObservableCollection<Personaje> _listapersonajes;
        

        public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _buscarCommand;
        private String textoaBuscar;

        public clsMainPageVM()
        {
           _listatrilogia = new Listados().listTriologia();
           //_listapelicula = new Listados().listpeliculas();
           //_listapersonajes = new Listados().listpersonajes();
           _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
        }

        public DelegateCommand EliminarCommand
        {
            get
            {

                return _eliminarCommand;
            }


        }
        private bool EliminarCommand_CanExecuted()
        {
            bool posible = false;
            if (trilogiaSeleccionada != null)
            {
                posible = true;
            }
            
            return posible;
        }

        private void EliminarCommand_Executed()
        {
            if (personajeSeleccionado != null)
            {
                _listapersonajes.Remove(_personajeSeleccionado);
            }
            else if (_peliculaSeleccionada != null)
            {
                _listapelicula.Remove(_peliculaSeleccionada);
            }
            else
            {
                _listatrilogia.Remove(_trilogiaSeleccionada);
            }
        }

        #region getters&setters
        public ObservableCollection<Trilogia> listatrilogia
        {
            get
            {
                return this._listatrilogia;
            }
            set
            {
                this._listatrilogia = value;
                NotifyPropertyChanged("listatrilogia");
            }
        }

        public Trilogia trilogiaSeleccionada
        {
            get
            {
                return _trilogiaSeleccionada;
            }

            set
            {
                _trilogiaSeleccionada = value;

                listapelicula = new Listados().listpeliculas();
                listapersonajes = null;
                if (trilogiaSeleccionada != null)
                {
                    listapelicula = this.getPelis(_trilogiaSeleccionada.id);
                }else
                {
                    listapelicula = null;
                }
                _eliminarCommand.RaiseCanExecuteChanged();

                
               NotifyPropertyChanged("trilogiaSeleccionada");

            }
        }

        public ObservableCollection<Pelicula> listapelicula
        {
            get
            {
                return this._listapelicula;
            }
            set
            {
                this._listapelicula = value;
                NotifyPropertyChanged("listapelicula");

            }
        }

        public Pelicula peliculaSeleccionada
        {
            get
            {
                return _peliculaSeleccionada;
            }
            set
            {
                _peliculaSeleccionada = value;
                

                if (peliculaSeleccionada != null) {
                    listapersonajes = new Listados().listpersonajes();
                    listapersonajes = this.getPersonaje(_peliculaSeleccionada.id);
                }
                else
                {
                    listapersonajes = null;
                }
                NotifyPropertyChanged("peliculaSeleccionada");
                
                
            }
        }


        public ObservableCollection<Personaje> listapersonajes
        {
            get
            {
                return this._listapersonajes;
            }
            set
            {
                this._listapersonajes = value;
                NotifyPropertyChanged("listapersonajes");
            }
        }


        public Personaje personajeSeleccionado
        {
            get
            {
                return this._personajeSeleccionado;
            }
            set
            {
                this._personajeSeleccionado = value;
                NotifyPropertyChanged("personajeSeleccionado");
            }
        }


        public DelegateCommand buscarCommand
        {
            get
            {
               // _buscarCommand = new DelegateCommand(buscarCommand_Executed);
                return _buscarCommand;
            }
        }


        #endregion
        #region funciones

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<Pelicula> getPelis(int id)
        {
            ObservableCollection<Pelicula> pelis = new ObservableCollection<Pelicula>();

            for(int i = 0; i < this.listapelicula.Count; i++)
            {
                if (this.listapelicula.ElementAt(i).idtrilogia == id)
                {
                    pelis.Add(this._listapelicula.ElementAt(i));
                }
            }
            return pelis;

        }


        public ObservableCollection<Personaje> getPersonaje(int id)
        {
            ObservableCollection<Personaje> personajes = new ObservableCollection<Personaje>();

            for (int i = 0; i < this._listapersonajes.Count; i++)
            {
                if (this._listapersonajes.ElementAt(i).idpelicula == id)
                {
                    personajes.Add(this._listapersonajes.ElementAt(i));
                }
            }
            return personajes;

        }
        #endregion
    }
}
