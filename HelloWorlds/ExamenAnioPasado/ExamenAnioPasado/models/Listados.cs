using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnioPasado.viewModels
{
    public class Listados
    {



        
        public ObservableCollection<Trilogia> listTriologia()
        {
            ObservableCollection<Trilogia> trilogias=new ObservableCollection<Trilogia>();


            //trilogias
            Trilogia trilogia1 = new Trilogia("Trilogia1",1);
            Trilogia trilogia2 = new Trilogia("Trilogia2",2);

            trilogias.Add(trilogia1);
            trilogias.Add(trilogia2);

            
            return trilogias;
        }


        public ObservableCollection<Pelicula> listpeliculas()
        {
            ObservableCollection<Pelicula> pelis=new ObservableCollection<Pelicula>();

            //peliculas


            //para la primera trilogia
            Pelicula pelicula1 = new Pelicula("Pelicula 1", 1, 1);



            Pelicula pelicula2 = new Pelicula("Pelicula 2", 2, 1);



            Pelicula pelicula3 = new Pelicula("Pelicula 3", 3, 1);




            //para la segunda trilogia
            Pelicula pelicula4 = new Pelicula("Pelicula 4", 4, 2);

            Pelicula pelicula5 = new Pelicula("Pelicula 5", 5, 2);



            Pelicula pelicula6 = new Pelicula("Pelicula 6", 6, 2);

            pelis.Add(pelicula1);
            pelis.Add(pelicula2);
            pelis.Add(pelicula3);
            pelis.Add(pelicula4);
            pelis.Add(pelicula5);
            pelis.Add(pelicula6);

            return pelis;
        }

        public ObservableCollection<Personaje> listpersonajes()
        {
            ObservableCollection<Personaje> p = new ObservableCollection<Personaje>();

            //personajes
            Personaje p1 = new Personaje("Personaje1", 1, 1,"ms-appx://_ExamenAnioPasado/Assets/andalucia4dic.mp3");


            Personaje p2 = new Personaje("Personaje2", 2, 2, "ms-appx://_ExamenAnioPasado/Assets/andalucia4dic.mp3");


            Personaje p3 = new Personaje("Personaje3", 3, 3, "ms-appx://_ExamenAnioPasado/Assets/andalucia4dic.mp3");


            Personaje p4 = new Personaje("Personaje4", 4, 4, "ms-appx://_ExamenAnioPasado/Assets/andalucia4dic.mp3");


            Personaje p5 = new Personaje("Personaje5", 5, 5, "ms-appx://_ExamenAnioPasado/Assets/andalucia4dic.mp3");


            Personaje p6 = new Personaje("Personaje6", 6, 6, "ms-appx://_ExamenAnioPasado/Assets/andalucia4dic.mp3");

            p.Add(p1);
            p.Add(p2);
            p.Add(p3);
            p.Add(p4);
            p.Add(p5);
            p.Add(p6);


            return p;
        }
    }
}
