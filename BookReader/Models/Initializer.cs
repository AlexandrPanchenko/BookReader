using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace BookReader.Models
{
   public class Initializer: DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            Author author = new Author() { Name = "Джеффри", Surname = "Рихтер", Description = " компьютерный специалист, автор наиболее хорошо продаваемых книг в области Win32 и .NET. Рихтер — соучредитель компании Wintellect, которая обучает ИТ-специалистов и консультирует фирмы в области создания ПО. За годы работы Рихтер консультировал Intel, DreamWorks и Microsoft. Рихтер внёс вклад в следующие проекты: Windows NT 32 и 64, Visual Studio .NET, Microsoft Office, TerraServer, .NET Framework, Windows Vista. Джеффри Рихтер автор колонки .NET в журнале MSDN.", ImagePath = "/Content/AuthorsImage/Richter.jpg" };
            Author author2 = new Author() { Name = "Стив", Surname = "Макконнелл", Description = " программист, автор книг по разработке ПО. Написал книги «Rapid Development» (1996), «Software Project Survival Guide» (1998), «Professional Software Development» (2004). Журнал «Software Development» дважды удостоил его книги премии Jolt Excellence как лучшие книги года о разработке ПО. В 1998 году читатели этого журнала признали Стива одним из трех наиболее влиятельных людей в отрасли разработки ПО наряду с Биллом Гейтсом и Линусом Торвальдсом", ImagePath = "/Content/AuthorsImage/Stiv_Makkonnell.jpg" };
            Category category = new Category() { Name = "Программирование" };
            Book book = new Book() { Name = "CLR via C#", Rating = 0, Year = 2012, CreateTime = DateTime.Now, ImagePath = "/Content/BookImage/CLR.jpg", ContentPath = "/Content/Books/CLR.pdf", language = "русский", Description= "Эта книга, выходящая в третьем издании и уже ставшая классическим учебником по программированию, подробно описывает внутреннее устройство и функционирование общеязыковой исполняющей среды (CLR) Microsoft .NET Framework версии 4.0. Написанная признанным экспертом в области программирования Джеффри Рихтером, много лет являющимся консультантом команды разработчиков .NET Framework компании Microsoft, книга научит вас создавать по-настоящему надежные приложения любого вида, в том числе с использованием Microsoft Silverlight, ASP.NET, Windows Presentation Foundation и т.д. Третье издание полностью обновлено в соответствии со спецификацией платформы.NET Framework 4.0 и принципами многоядерного программирования.", Authors= new List<Author>() {author } };
            Book book2 = new Book() { Name = "Совершенный код", Rating = 0, Year = 2010, CreateTime = DateTime.Now, ImagePath = "/Content/BookImage/Stiv_Makkonnell.gif", ContentPath = "/Content/Books/Stiv_Makkonnell.pdf", language = "русский", Description= "Более 10 лет первое издание этой книги считалось одним из лучших практических руководств по программированию. Сейчас эта книга полностью обновлена с учетом современных тенденций и технологий и дополнена сотнями новых примеров, иллюстрирующих искусство и науку программирования. Опираясь на академические исследования, с одной стороны, и практический опыт коммерческих разработок ПО - с другой, автор синтезировал из самых эффективных методик и наиболее эффективных принципов ясное прагматичное руководство. Каков бы ни был ваш профессиональный уровень, с какими бы средствами разработками вы ни работали, какова бы ни была сложность вашего проекта, в этой книге вы найдете нужную информацию, она заставит вас размышлять и поможет создать совершенный код. Книга состоит из 35 глав, предметного указателя и библиографии", Authors = new List<Author>() { author2 } };
           
            context.Authors.Add(author);
            context.Authors.Add(author2);
            context.Books.Add(book);
            context.Books.Add(book2);
            context.Categories.Add(category);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
