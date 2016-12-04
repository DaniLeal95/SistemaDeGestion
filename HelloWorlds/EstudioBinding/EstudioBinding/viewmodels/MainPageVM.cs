using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioBinding.viewmodels
{
   public class MainPageVM:clsVMBase
    {
        private clsPersona _personaSeleccionada;


        
        private ObservableCollection<clsPersona> _lista;
        private DelegateCommand _anadirCommand;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _buscarCommand;
        private String _textoaBuscar;

        //private String _nombre;
        //private String _apellidos;
        //private String _telefono;
        //private String _descripcion; 

        public MainPageVM()
        {
            _buscarCommand = new DelegateCommand(BuscarCommand_Executed, BuscarCommand_CanExecuted);
            _eliminarCommand= new DelegateCommand(EliminarCommand_Executed,EliminarCommand_CanExecuted);
            _anadirCommand = new DelegateCommand(AnadirCommand_Executed);
            _lista = new clsListado().list;
        }

        #region getters&setters{

        public clsPersona personaSeleccionada
        {
            get
            {
                return this._personaSeleccionada;

            }
            set
            {
                _personaSeleccionada = value;
                _eliminarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
            }
        }

        public ObservableCollection<clsPersona> lista
        {
            get
            {
                return _lista;
            }
            set
            {
                this._lista = value;
            }
        }

        public DelegateCommand eliminarComand
        {
            get
            {
                return this._eliminarCommand;
            }
        }

        public DelegateCommand buscarComand
        {
            get
            {
                return this._buscarCommand;

            }
        }
    
        public DelegateCommand anadirCommand
        {
            get
            {
                return this._anadirCommand;
            }
        }

        public String textoabuscar
        {
            get
            {
                return this._textoaBuscar;
            }
            set
            {
                _textoaBuscar = value;
                _buscarCommand.RaiseCanExecuteChanged();
            }
        }

        //public String nombrevm
        //{
        //    get
        //    {
        //        return this._nombre;
        //    }
        //    set
        //    {
        //        anadirCommand.RaiseCanExecuteChanged();
        //        this._nombre = value;
        //    }
        //}

        //public String apellidosvm
        //{
        //    get
        //    {
        //        return this._apellidos;
        //    }
        //    set
        //    {
        //        anadirCommand.RaiseCanExecuteChanged();
        //        this._apellidos = value;
        //    }
        //}

        //public String telefonovm
        //{
        //    get
        //    {
        //        return this._telefono;
        //    }
        //    set
        //    {
        //        this._telefono = value;
        //    }
        //}
        //public String descripcionvm
        //{
        //    get
        //    {
        //        return this._descripcion;
        //    }
        //    set
        //    {
        //        this._descripcion = value;
        //    }
        //}



        #endregion

        #region funciones

        //EliminarCommands
        public bool EliminarCommand_CanExecuted()
        {
            bool posible = false;

            if (_personaSeleccionada!=null) { posible = true; }
            return posible;

        }
        public void EliminarCommand_Executed()
        {
            _lista.Remove(_personaSeleccionada);
            _personaSeleccionada = null;
        }

        //BuscarCommands
        public bool BuscarCommand_CanExecuted()
        {
            bool posible=true;
           
            return posible;
        }
        public void BuscarCommand_Executed()
        {

            _lista = new clsListado().list;
            if (!String.IsNullOrEmpty(_textoaBuscar))
            {
                var query = from p in _lista where p.nombre.Contains(_textoaBuscar) || p.apellido.Contains(_textoaBuscar) select p;
                _lista =new ObservableCollection < clsPersona > (query);

            }

            NotifyPropertyChanged("lista");
        }

        //GuardarCommands

        public bool AnadirCommand_CanExecuted()
        {
            return true;
        }
        public void AnadirCommand_Executed()
        {

            //DateTime d = new DateTime(1995, 10, 12);
            //clsPersona p = new clsPersona(this._nombre, this._apellidos, d, this._telefono, this._descripcion);

            //_lista.Add(p);

        }


        #endregion


    }
}
