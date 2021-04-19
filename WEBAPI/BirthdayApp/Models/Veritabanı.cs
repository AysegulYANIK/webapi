using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirthdayApp.Models
{
    public class Veritabanı
    {
        private static Dictionary<string, Davetiye> _liste;
         
        static Veritabanı()
        {
            _liste = new Dictionary<string, Davetiye>();

            _liste.Add("Ayşegül", new Davetiye
                {
                    Ad = "Ayşegül",
                    Eposta = "aysegul@mail.com",
                    KatilmaDurumu = true
                }
            );

            _liste.Add("Mertkan", new Davetiye
            {
                Ad = "Mertkan",
                Eposta = "mertkan@mail.com",
                KatilmaDurumu = false
            }
            );

            _liste.Add("Sema", new Davetiye
            {
                Ad = "Sema",
                Eposta = "sema@mail.com",
                KatilmaDurumu = true
            }
            );

            _liste.Add("Aydın", new Davetiye
            {
                Ad = "Aydın",
                Eposta = "aydin@mail.com",
                KatilmaDurumu = true
            }
            );
        }

        public static void Add(Davetiye model)
        {
            string key = model.Ad.ToLower();
            if(_liste.ContainsKey(key))
            {
                _liste[key] = model;
            }

            else
            {
                _liste.Add(key, model);
            }
        }

        public static IEnumerable<Davetiye> Liste
        {
            get { return _liste.Values; }
        }

    }
}