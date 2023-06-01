using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmYorum.DataSource;
using FilmYorum.Models;
using FilmYorum.Repository.Interfaces;

namespace FilmYorum.Repository
{
    internal class FilmRepository : IRepository<Films>
    {
        private DataContext db = new DataContext();

        public bool Add(Films entity)
        {
            bool result = false;
            if (entity != null)
            {
                db.Films.Add(entity);
                result = !result;
                db.SaveChanges();
            }
            return result;
        }

        public bool Delete(int id)
        {
            Films Film = db.Films.FirstOrDefault(f => f.Id == id);
            bool result = false;
            if (Film != null)
            {
                Film.IsDelete = true;
                result = true;
            }
            return result;
        }

        public Films Get(int id) => db.Films.FirstOrDefault(f => f.Id == id && !f.IsDelete && f.IsStatus == true);


        public List<Films> GetAll()
        {
            return db.Films.Where(x => x.IsDelete == false).ToList();
        }


        public bool Update(Films entity)
        {
            bool result = false;
            var film = db.Films.Find(entity.Id);
            if (film != null)
            {
                film.Name = String.IsNullOrWhiteSpace(entity.Name) ? film.Name : entity.Name;
                film.Description = entity.Description;
                film.Director = entity.Director;
                film.Year = entity.Year;
                film.IsStatus = entity.IsStatus;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public void seedData()
        {
            db.Films.Add(new Films
            {
                Name = "Aşk ve Gurur",
                Description = "Jane Austen'ın 1813'te yayımlanan Gurur ve Önyargı kitabından uyarlanan, 2005 yapımı romantik dram filmi. Film toprak sahibi seçkinlerinden olan bir İngiliz ailesindeki beş kız kardeşin evlilik, ahlak ve kavram yanılgılarının sorunları ile uğraşmasını konu alıyor.",
                Director = "Joe Wright",
                Year = 2005,
                Genre = Genre.Romantic.ToString(),
                IsStatus = true
            });
            db.Films.Add(new Films
            {
                Name = "G.O.R.A.",
                Description = "Sahte UFO fotoğrafçısı ve halı tüccarı olan Arif uzaylılarca kaçırılır. Gora gezegeninde, yaklaşan göktaşından kurtulmak ve özgür kalmak için arkadaşlarına yardım eder.",
                Director = "Ömer Faruk Sorak",
                Year = 2004,
                Genre = Genre.Comedy.ToString(),
                IsStatus = true
            });
            db.Films.Add(new Films
            {
                Name = "Aashiqui 2",
                Description = "Dünyaca ünlü bir şarkıcı olan RJ (Rahul Jaykar) artık eski günlerindeki gibi değildir, başarısız bir konser çıkışı tanıştığı Aarohi Keshav Shirke'ye aşık olur ve onun sesinden etkilenir. Onu başarılı bir şarkıcı yaptıktan sonra bağımlısı olduğu alkol yüzünden sesini kaybeder ve artık depresyona girer. Aarohi onu kurtarmaya çalışsa da nafiledir. Aarohi'nin kendisiyle beraber batmayı göze aldığını duyan Rahul köprüden kendini denize atarak intihar eder.",
                Director = "Mohit Suri",
                Year = 2013,
                Genre = Genre.Drama.ToString(),
                IsStatus = true
            });
            db.Films.Add(new Films
            {
                Name = "Kingsman: The Secret Service",
                Description = "Kingsman: Gizli Servis, yönetmenliğini Matthew Vaughn'un üstlendiği, Dave Gibbons ve Mark Millar'ın The Secret Service adlı çizgi romanından uyarlanan casusluk, aksiyon ve komedi türlerindeki 2014 yapımı Amerikan-Britanya filmi. ",
                Director = "Matthew Vaughn",
                Year = 2014,
                Genre = Genre.Action.ToString(),
                IsStatus = true
            });

        }
    }
}
