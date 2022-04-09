namespace MyCrud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            helpEntities databases = new helpEntities();
            List<MyModel> mm = new List<MyModel>();
            var res = database.mytable.ToList();
            foreach (var item in res)
            {
                mm.Add(new mm
                {
                    id=item.id,
                    name=item.name,
                    email=item.email,
                    city=item.city,
                    salary=item.salary
                });
            }
            return View("mm");
        }
	
		[HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(MyModel obj)
        {
            helpEntities database = new helpEntities();
            mytable tbl = new mytable();
            tbl.id = obj.id;
            tbl.name = obj.name;
            tbl.email = obj.email;
            tbl.city = obj.city;
            tbl.salary = obj.salary;

            if (obj.id == 0)
            {
                database.mytable.Add(tbl);
                dataBase.SaveChanges();
            }
            else
            {
                dataBase.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
                dataBase.SaveChanges();
            }
           
            return RedirectToAction("Index","Home");
          
        }

        public ActionResult Edit(int id)
        {
            myModel obj = new myModel();
            helpEntities obj = new helpEntities();
            var Editing = dataBase.mytable.Where(a => a.id == id).First();
            obj.id = Editing.id;
            obj.name = Editing.name;
            obj.email = Editing.email;
            obj.city = Editing.city;
            obj.salary = Editing.salary;
            ViewBag.id = Editing.id;

            return View("Index",obj);
        }

        public ActionResult Delete(int id)
        {
            help2Entities dataBase = new help2Entities();
            var del = dataBase.mytable.Where(b => b.id == id).First();
            dataBase.mytable.Remove(del);
            database.SaveChanges();
            return RedirectToAction("Index","Home");
        }
	}
}