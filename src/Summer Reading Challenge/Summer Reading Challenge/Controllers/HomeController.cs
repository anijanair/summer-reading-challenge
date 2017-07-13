using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Summer_Reading_Challenge.Models;


namespace Summer_Reading_Challenge.Controllers
{
    public class HomeController : Controller
    {
        private BookContext _entities = new BookContext();


        // GET: Home
        public ActionResult Index()
        {
            return View(_entities.Books.ToList());
        }

        // GET: Home/Details
        //If Id or book is null, return bad request or HTTP not found response. 
        //If not, find the id and display it.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _entities.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        // GET: Home/Create
        public ActionResult Add()
        {
            return View();
        }


        // POST: Home/Create
        // Using Bind to limit the fields available for CRUD activity.
        [HttpPost]
        public ActionResult Add([Bind(Exclude = "Id")]Book book)
        {
            if(ModelState.IsValid)
            {
                _entities.Books.Add(book); 

                _entities.SaveChanges();

                return RedirectToAction("Index");
            }           
            
                return View(book);
            
        }

        // GET: Home/Edit
        public ActionResult Edit(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _entities.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Home/Edit
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Date,BookTitle,Author")] Book book)
        {
            if (ModelState.IsValid)
            {
                _entities.Entry(book).State = EntityState.Modified;

                _entities.SaveChanges();

                return RedirectToAction("Index");
            }
            
                return View(book);
        }
        // GET: Home/Delete
        public ActionResult Delete(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _entities.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        // POST: Home/Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Book book = _entities.Books.Find(id);

            _entities.Books.Remove(book);

            _entities.SaveChanges();

          return RedirectToAction("Index");


        }
        
    }
}
