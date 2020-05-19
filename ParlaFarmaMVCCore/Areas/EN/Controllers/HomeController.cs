using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ParlaFarmaMVCCore.Models;
using ParlaFarmaMVCCore.API;
using ParlaFarmaMVCCore.Data;
using ParlaFarmaMVCCore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ParlaFarmaMVCCore.Areas.EN.Controllers
{
    [Area("EN")]
    public class HomeController : Controller
    {
        public List<string[]> DictStr = new List<string[]>();
        public List<string[]> DictStr1 = new List<string[]>()
        {
            new string[]{ "0", "Opening Hours: Mon - Sat 9:00 – 18:00", "Açılış saatları: Mon - Sat 9:00 - 18:00", "" },
            new string[]{ "1",  "Follow Us:", "Bizi izlə:", "" },
            new string[]{ "2", "Home", "Əsas səhifə", "" },
            new string[]{ "3", "About Us", "Haqqımızda", "" },
            new string[]{ "4", "Our Company", "Şirkətimiz", "" },
            new string[]{ "5", "Our Vision", "Vizyonumuz", "" },
            new string[]{ "6", "Our Mission", "Missiyamız", "" },
            new string[]{ "7", "Our Values", "Dəyərlərimiz", "" },
            new string[]{ "8", "Our Team", "Komandamız", "" },
            new string[]{ "9", "Our Culture", "Korporativ mədəniyyət", "" },
            new string[]{ "10", "Social Responsibility", "Sosial məsuliyyət", "" },
            new string[]{ "11", "Products", "Məhsullar", "" },
            new string[]{ "12", "By alphabet", "Əlifba sırası üzrə", "" },
            new string[]{ "13", "By problem", "Xəstəlik üzrə", "" },
            new string[]{ "14", "Phramacovigilance", "Farmakonəzarət", "" },
            new string[]{ "15", "News and Media", "Xəbərlər", "" },
            new string[]{ "16", "News", "Xəbərlər", "" },
            new string[]{ "17", "Press-releases", "Pres-relizlər", "" },
            new string[]{ "18", "Media gallery", "Media qalereya", "" },
            new string[]{ "19", "Partners", "Tərəfdaşlıq", "" },
            new string[]{ "20", "Distributors", "Distribyutorlar", "" },
            new string[]{ "21", "Export development", "İxrac xətti", "" },
            new string[]{ "22", "Careers", "Karyera", "" },
            new string[]{ "23", "Why Parla", "PARLA-da iş", "" },
            new string[]{ "24", "Vacancies", "Vakansiyalar", "" },
            new string[]{ "25", "Application form", "Müraciət formu", "" },
            new string[]{ "26", "Contact Us", "Əlaqə", "" },
            new string[]{ "27", "Shine for Health", "Sağlam həyat üçün!", "" },
            new string[]{ "28", "We promise a healthier tomorrow for our patients", "Biz daha sağlam gələcək naminə çalışırıq.", "" },
            new string[]{ "29", "Discover Now", "Daha ətraflı", "" },
            new string[]{ "30", "Our aim is to improve healthcare access and quality of life", "Bizim məqsədimiz səhiyyə xidmətlərinin daha əlçatan olmasına nail olmaq və insanların həyat keyfiyyətlərini yaxşılaşdırmaqdır.", "" },
            new string[]{ "31", "We focus on contributing to benefit our patientsWe focus on contributing to benefit our patients, society and environment", "Cəmiyyətimizə, pasiyentlərimizə və ətraf mühitə öz töhfəmizi vermək üçün dayanmadan çalışırıq.", "" },
            new string[]{ "32", "Welcome to Our Website", "Vebsaytımıza xoş gəlmisiniz!", "" },
            new string[]{ "33", "We are the first science-based pharmaceutical company in Azerbaijan, focusing on the full production of high-technology medicines.", "“Parla Pharmaceuticals” yüksək texnologiyalı dərmanların tam istehsalına yönəlmiş Azərbaycanda ilk elmi əsaslı əczaçılıq şirkətidir.", "" },
            new string[]{ "34", "Parla Team", "Komandamız", "" },
            new string[]{ "35", "Parla Culture", "Korporativ mühit", "" },
            new string[]{ "36", "Check It", "Daha ətraflı", "" },
            new string[]{ "37", "Improving health care access and quality of life", "Səhiyyə xidmətlərinə çıxışı və pasiyentlərin həyat keyfiyyətini yaxşılaşdırmaq", "" },
            new string[]{ "38", "Creating added value for  our customers, staff, business partner and  shareholders", "Müştərilərimiz, əməkdaşlarımız, biznes tərəfdaşlarımız və səhmdarlarımız üçün əlavə dəyər yaratmaq", "" },
            new string[]{ "39", "Establishing a first class Pharmaceutical company in Azerbaijan and all CIS region", "Azərbaycanda və bütün MDB regionunda ən qabaqcıl əczaçılıq şirkətinə çevrilmək", "" },
            new string[]{ "40", "Developing customer orientation and leadership in the market", "Bazarda müştəri yönümlü yanaşma və liderliyi inkişaf etdirmək", "" },
            new string[]{ "41", "Offering high quality products with most affordable prices for customers", "Münasib qiymət və yüksək keyfiyyətli dərman məhsulları təmin etmək", "" },
            new string[]{ "42", "Creating raving fans among clients and customers", "Müştərilər üçün güvənli tərəfdaşa çevrilmək", "" },
            new string[]{ "43", "Why Parla?", "Nə üçün PARLA?", "" },
            new string[]{ "44", "We have passion to help patients", "Pasiyentlər bizim üçün önəmlidir", "" },
            new string[]{ "45", "Improving quality of life of patients is focus of Parla. We make sure this will be the base of all our decisions and actions. we make our medicine available and affordable for the patients.", "PARLAnın əsas maraqlarından biri pasiyentlərin həyat keyfiyyətinin yaxşılaşdırılmasıdır. Bu, bizim aldığımız bütün qərarların və fəaliyyətimizin əsasında dayanır.", "" },
            new string[]{ "46", "We offer a best place to work to our employees", "Biz əməkdaşlarımıza ən yaxşı iş yeri təklif edirik", "" },
            new string[]{ "47", "We offer a nice and welcome working environment to help people to learn and grow. We believe in empowerment together with support which help people to develop their skills in high standards.", "Xoş və rahat iş mühiti təmin etməklə, əməkdaşlarımızın öyrənərək inkişaf etməsinə şərait yaradırıq. Bizim üçün əməkdaşlarımızın peşəkar və fərdi inkişafı böyük önəm kəsb edir.", "" },
            new string[]{ "48", "We use innovation and advance technology to provide the best products with high standards", "İnnovasiya və yüksək texnologiya əsasında keyfiyyətli dərman məhsulları təmin edirik", "" },
            new string[]{ "49", "As the first science-based pharmaceutical company of Azerbaijan, we focus on the full production of high-tech products. Our portfolio also includes biotechnological and nanotechnological products. We provide high quality pharmaceutical products with high GMP standards.", "Azərbaycanın ilk elmi əsaslı əczaçılıq şirkəti olaraq, yüksək texnologiyalı dərmanların istehsalını həyata keçirməyə yönəlmişik. Məhsul portfelimizə,həmçinin, biotexnoloji və nanotexnoloji dərmanlar da daxildir. Yüksək keyfiyyətli əczaçılıq məhsulları yüksək GMP standartlarına cavab verir.", "" },
            new string[]{ "50", "We are responsible for our society and our environment", "Biz cəmiyyət və ətraf mühit qarşısındakı məsuliyyətlərimizi dərk edirik", "" },
            new string[]{ "51", "To have a sustainable business, Parla is responsible for its society and environment. We collaborate with related stakeholders in our disease areas as a part of social responsibility activities. Also, to keep our planet safe for all of us, we have some policies which underpins every decision and action we make.", "Biznesin dayanıqlılığına nail olmaq üçün PARLA öz qarşısına cəmiyyət və ətraf mühitlə bağlı məsuliyyətlər qoyub. Biz bütün fəaliyyətimizdə bu sosial məsuliyyət öhdəliklərini qəbul edir və bu istiqamətdə müvafiq tərəflərlə əməkdaşlıq edərək Korporativ Sosial Məsuliyyət (KSM) layihələri həyata keçiririk.", "" },
            new string[]{ "52", "“Parla Pharmaceuticals” headquartered in Azerbaijan ,established in 2019, is the first science-based pharmaceutical company of Azerbaijan, focusing on the full production of high-technology medicines.", "“Parla Pharmaceuticals” Azərbaycanda ilk elmi əsaslı əczaçılıq şirkətidir. Şirkətimiz 2019-cu ildə yaradılıb. Parlanın fəaliyyəti Azərbaycanda yüksək texnologiyalı dərmanların tam istehsalından ibarətdir.", "" },
            new string[]{ "53", "The initial aim is to increase quality of lives of patients and their access to high quality pharmaceutical products with affordable price produced by Parla Pharmaceuticals. Our mission is to develop customer orientation and leadership in the pharmaceutical market and community.", "Əsas məqsədimiz əhalinin həyat keyfiyyətinin artırıılması, yüksək keyfiyyətli əczaçılıq məhsulları istehsal edərək münasib qiymətlərlə insanlara təqdim etməkdir. Biz həmçinin, əczaçılıq bazarında və cəmiyyətdə pasiyent yönümlü yanaşmanı və liderliyi inkişaf etdirməyə yönəlmişik.", "" },
            new string[]{ "54", "Exporting advanced biotechnological and nanotechnological products by developing an international culture, structure and performanceis one of the key focus areas. Parla is ambitious to be Azerbaijan’s best Pharmaceutical brand, worldwide.", "Məhsul portfelimizdə klassik dərman vasitələri ilə yanaşı müasir biotexnoloji və nanotexnoloji məhsullar da olacaq. Parla bu məhsulların Azərbaycanda satışı ilə yanaşı, onların ixracını da həyata keçirəcək. Parla Azərbaycanın qabaqcıl əczaçılıq brendi olmaqda iddialıdır.", "" },
            new string[]{ "55", "With the footprint and commitment to improving access to healthcare and improving quality of life, Parla works tirelessly to make a difference to people’s lives every day and focuses on transferring scientific innovation. This will be aligned with social and environmental focus.", "Səhiyyə xidmətlərinin daha əlçatan olmasına nail olmaq və insanların həyat keyfiyyətinin yaxşılaşdıırlmasına öz töhfəsini vermək üçün Parla dayanmadan çalışır və elmi innovasiyanın, yeniliklərin tətbiqini də diqqətdə saxlayır. Biz həmçinin sosial və ətraf  mühitlə bağlı öhdəliklərimizi də həyata keçiririk.", "" },
            new string[]{ "56", "Our team is our main asset. Parla is a young, talented, ambitious and agile team of professionals", "“Parla” gənc, istedadlı, məqsədyönlü və çevik peşəkarlar komandasıdır!", "" },
            new string[]{ "57", "We are a dynamic and energetic team of professionals who focus on excellence and success. Our people are equipped with many years of experience, along with the knowledge and confidence in their field of work. In Parla we believe in innovation, dedication and teamwork.", "Biz yüksək professionallıq və uğur qazanmaq yolunda  irəliləyən dinamik və enerjili peşəkarlardan ibarət komandayıq. Bizim əməkdaşlarımız öz sahələrində ekspert olmaqla yanaşı, həm də çoxillik təcrübəyə malikdirlər. “Parla” olaraq, biz innovasiya, sadiqlik və komanda işinə inanırıq.", "" },
            new string[]{ "58", "With a well-trained professional team and abundance of experience behind them, Parla is determined to become a first-class pharmaceutical company in Azerbaijan. Our success is a reflection of our people and we love what we do", "Geniş təcrübəyə malik və çoxsaylı təlim keçmiş peşəkarlar komandası ilə, “Parla” Azərbaycanda qabaqcıl əczaçılıq şirkəti olmaqda qərarlıdır. Bizim uğurumuz əməkdaşlarımızın fəaliyyətindən yaranır. Çünki biz öz işimizi sevirik !", "" },
            new string[]{ "59", "We believe that success of our business depends directly on personal contribution of every employee. Our teamwork is based on learning culture, effetive communication, constructive feedback and determination.", "Biz əminik ki, biznesin uğuru hər bir əməkdaşın fərdi tohfəsinə əsaslanır. Komanda fəaliyyətimzidə öyrənmək və inkişaf, şəffaf və açıq ünsiyyət, konstruktiv rəy və qərarlılıq prinsiplərini əsas tuturuq.", "" },
            new string[]{ "60", "Staying true to our mission, values and culture we focus on contributing to benefit our patients, society and environment", "Missiyamız, dəyərlərimiz və korporativ mədəniyyətimizə sadiq qalaraq, pasiyentlərimiz, cəmiyyətimiz və ətraf mühitə öz töhfəmizi vermək üçün dayanmadan çalışırıq.", "" },
            new string[]{ "61", "Job Application", "İş üçün müraciət forması", "" },
            new string[]{ "62", "Thank you for your interest in working with us. Please check below for available job opportunities that meet your criteria and send your application by filling out the Job Application Form.", "Bizimlə işləməyə maraq göstərdiyiniz üçün təşəkkür edirik. Sizə uyğün mövcud iş imkanları üçün vakansiyalar bölməmizə baş çəkin və İş üçün Müraciət Formasını doldurmaqla ərizənizi bizə göndərin.", "" },
            new string[]{ "63", "Phone", "Telefon", "" },
            new string[]{ "64", "What position are you applying for?", "Hansı vəzifə üçün müraciət edirsiniz?", "" },
            new string[]{ "65", "Available start date", "Mümkün başlama tarixi", "" },
            new string[]{ "66", "We shine for a better future!", "Daha parlaq gələcək üçün!", "" },
            new string[]{ "67", "We know how to work and have fun at the same time", "Əgər siz də peşəkar komandamızın bir üzvü olmaq və daha parlaq gələcək üçün çalışmaq istəyirsinisə, bizə qoşulun!", "" },
            new string[]{ "68", "Why PARLA?", "Nə üçün PARLAnı seçməlisiniz?", "" },
            new string[]{ "69", "Values of PARLA is a key to success of the team and the main accelerator of our business.", "PARLA-da izlədiyimiz dəyərlər komandamızın uğurunun açarı və biznesimizin əsas mühərrikidir.", "" },
            new string[]{ "70", "Professionalism", "Professionallıq", "" },
            new string[]{ "71", "Teamwork", "Komanda işi", "" },
            new string[]{ "72", "Innovation", "İnnovasiya", "" },
            new string[]{ "73", "Performance", "Performans", "" },
            new string[]{ "74", "Motivation package", "Motivasiya paketi", "" },
            new string[]{ "75", "Development of talents", "İstedadların inkişafı", "" },
            new string[]{ "76", "Fun-loving corporate culture", "Pozitiv korporativ mühit", "" },
            new string[]{ "77", "Comfortable workplace", "Rahat iş yeri", "" },
            new string[]{ "78", "To potential distributors:", "Potensial distribyutorlara:", "" },
            new string[]{ "79", "PARLA is interested in engaging new partners:", "PARLA bu meyarlar üzrə yeni tərəfdaşlar cəlb etməkdə maraqlıdır:", "" },
            new string[]{ "80", "Actively developing sales of medicinal products.", "Dərman məhsullarının satışını aktiv inkişaf etdirmək;", "" },
            new string[]{ "81", "Having strong positions at local markets.", "Yerli bazarlarda güclü mövqeyə sahib olmaq;", "" },
            new string[]{ "82", "Having marketing resources to promote medicinal products of PARLA.", "PARLAnın dərman vasitələrini tanıtmaq üçün marketinq resurslarına sahib olmaq.", "" },
            new string[]{ "83", "The purpose of promotion is defining objective criteria to choose potential Commercial partners and to assess current Commercial Partners as well as willing to make this process as understandable and transparent as possible.", "Tərəfdaşlıqda maraqlı olan mövcud və yeni partnyorlarla əməkdaşlıq təkliflərinə açığıq.", "" },
            new string[]{ "84", "Export development is an important element of the “Parla Pharmaceuticals” business strategy.", "Dərman məhsullarının ixracı “Parla Pharmaceuticals” şirkətinin biznes strategiyasının əsas istiqamətlərindən biridir.", "" },
            new string[]{ "85", "“Parla Pharmaceuticals” intends to export advanced biotechnological and nanotechnological products being developed in accordance with national and international GMP standards.", "“Parla Pharmaceuticals” beynəlxalq GMP standartlarına uyğun olaraq hazırlanan biotexnoloji və nanotexnoloji dərman məhsullarını ixrac etməyi planlaşdırır.", "" },
            new string[]{ "86", "As an ambitious company, we believe our work should be executed flawlessly, to guarantee added value for our patients, customers, shareholders and staff and ensure unparalleled quality in everything we do.", "İddialı bir şirkət olaraq, biz inanırıq ki, pasiyentlərimizə, müştərilərimizə, səhmdarlarımıza və işçi heyətimizə əlavə dəyər qatmaq və bütün fəaliyyətimizdə yüksək keyfiyyətə nail olmaq üçün işimizi qüsursuz icra etməliyik.", "" },
            new string[]{ "87", "We set our standards high and we are ready to help team to add on  their skillsso that Parla’s team can exceed expectations and strive for perfection in everything we do.", "Biz standartlarımızı yüksək təyin edir və komandamızın bu gözləntiləri doğrultması, eyni zamanda öz işində mükəmməl nəticələrə nail olması üçün onların səriştə və bacarıqlarının daim artırılmasına çalışırıq.", "" },
            new string[]{ "88", "We constantly strive to redefine the standard of excellence in everything we do. We are open to ideas that challenge the conventional views and drive innovation.", "Gördüyümüz hər işdə mükəmməllik standartlarını yenidən nəzərdən keçiririk. Biz ənənəvi baxış bucağına meydan oxuyan və yenilik gətirən fikirlərə hər zaman açığıq.", "" },
            new string[]{ "89", "Parla deeply believes in real team performance and integration. We put the interest of the team as success only comes when we work together.", "PARLAda biz həqiqi komanda işinə inanırıq. Bizim üçün komandanın marağı öndə gəlir, çünki güc birlikdədir.", "" },
            new string[]{ "90", "Integrity", "Dürüstlük", "" },
            new string[]{ "91", "Ethics is propriety in all what we do in Parla. We are honest, fair and open and we never compromise on those.", "Etik qaydalar bütün işimizin təməlidir. Biz dürüst, ədalətli və şəffafıq. Bu dəyərlərdə heç vaxt güzəştə getmirik.", "" },
            new string[]{ "92", "Contact Form", "Bizə yazın", "" },
            new string[]{ "93", "Full Name", "Ad, soyad", "" },
            new string[]{ "94", "Email address", "E-mail", "" },
            new string[]{ "95", "Phone", "Əlaqə nömrəsi", "" },
            new string[]{ "96", "Subject", "Mövzu", "" },
            new string[]{ "97", "Send", "göndərin", "" },
            new string[]{ "98", "Type Your ResumeURL", "ResumeURL * yazın", "" },
            new string[]{ "99", "Our Product Strategy", "Məhsul strategiyamız", "" },
            new string[]{ "100", "Parla has mainly been established to be an international player in pharmaceutical sector. In order to achieve such ambitious goals, there is a mandate internally to focus on QUALITY OF PRODUCTS. Parla is committed to provide high quality products with affordable price. Based on this strategy, Parla has defined its own product strategy very clear.", "Parla əczaçılıq sektorunda beynəlxalq oyunçulardan birinə çevrilməyi hədəfləyir. Bu cür iddialı məqsədlərə çatmaq üçün MƏHSULLARIN KEYFİYYƏTİ ƏSAS meyardır. Parlanın əsas missiyalarından biri münasib qiymətə yüksək keyfiyyətli məhsullar təqdim etməkdir. Parla özünün məhsul strategiyasını bu meyarlara əsaslanaraq müəyyən etmişdir.", "" },
            new string[]{ "101", "All products will be Parla’s properties, they will be branded and will be available worldwide with its unique strategy.", "Parla-ya məxsus bütün məhsullar unikal olacaq, özünəməxsus strategiyası ilə bütün dünyada satışa çıxarılacaq.", "" },
            new string[]{ "102", "Parla will have a very wide range of products which will be used in different therapeutic areas from OTC (Over the counter) products to high-tech anticancer treatments. However, some special focus areas are below:", "Parla-nın məhsul portfeli çoxçeşidli olmaqla, reseptsiz satılan dərman məhsullarından yüksək texnologiyalı, xərçəng əleyhinə müalicədə istifadə olunan dərmanlara qədər geniş sahəni əhatə edəcək. Dərmanların əhatə edəcəyi bir sıra terapevtik sahələr aşağıdakılardır:", "" },
            new string[]{ "103", "Cardiovascular", "Ürək-damar", "" },
            new string[]{ "104", "Endocrinology", "Endokrinologiya", "" },
            new string[]{ "105", "Gastroenterology", "Qastroenterologiya", "" },
            new string[]{ "106", "Inflammation", "İltihabəleyhinə", "" },
            new string[]{ "107", "Hematology", "Hematologiya", "" },
            new string[]{ "108", "Hemophilia", "Hemofiliya", "" },
            new string[]{ "109", "Thalassemia", "Talassemiya", "" },
            new string[]{ "110", "Oncology", "Onkologiya", "" },
            new string[]{ "111", "Neurology", "Nevrologiya", "" },
            new string[]{ "112", "Gynecology", "Ginekologiya", "" },
            new string[]{ "113", "Join the team of professionals in PARLA.", "PARLA-da peşəkar mütəxəssislər heyətinə qoşulun.", "" },
            new string[]{ "114", "Join us", "Bizə qoşul", "" },
            new string[]{ "115", "PARLA is a company attracting talents for realization potential and creates favourable working conditions for future success and achievements", "PARLA potensialı reallaşdırmaq üçün istedadları cəlb edən və gələcək uğur və uğurları üçün əlverişli iş şəraiti yaradan bir şirkətdir", "" },
            new string[]{ "116", "We offer:", "Biz təklif edirik:", "" },
            new string[]{ "117", "opportunity to become professional in your sphere and to increase expertise in the related areas", "öz sahəsində peşəkar olmaq və əlaqəli sahələrdə təcrübə artırmaq imkanı.", "" },
            new string[]{ "118", "to become company’s development driver, to implement ideas, innovations, projects together with the company.", "şirkətin inkişaf sürücüsü olmaq, şirkətlə birlikdə ideyalar, yeniliklər, layihələr həyata keçirmək.", "" },
            new string[]{ "119", "Postal Address:", "Poçt ünvanı:", "" },
            new string[]{ "120", "Fax:", "Faks:", "" },
            new string[]{ "121", "Initial aim is to produce high quality pharmaceutical products with affordable price and our mission is to develop customer orientation and leadership in the pharmaceutical market and community. Exporting advanced biotechnological and nanotechnological products is one of the key focus areas.", "Missiyamız yüksək keyfiyyətli, münasib qiymətə dərmanlar təqdim etməklə əczaçılıq bazarında müştəri yönümlülüyü və liderliyi inkişaf etdirməkdir. Yüksək texnologiyalı dərman məhsullarının ixracı da əsas fəaliyyət istiqamətlərimizdən biridir.", "" },
            new string[]{ "122", "First Name", "Ad", "" },
            new string[]{ "123", "High quality", "Yüksək keyfiyyət", "" },
            new string[]{ "124", "Advanced technology", "Yüksək texnologiya", "" },
            new string[]{ "125", "Affordable prices", "Münasib qiymət", "" },
            new string[]{ "126", "Corporate culture", "Korporativ mühit", "" },
            new string[]{ "127", "16E Keykab khanim Safaraliyeva, Time Business Center, 6th floor", "Kövkəb Səfərəliyeva küç. 16E, Time Business Mərkəzi, 6-cı mərtəbə", "" },
            new string[]{ "128", "Stay Tunned", "Bizi izləyin", "" },
            new string[]{ "129", "Last Name", "Soyad", "" },
            new string[]{ "130", "What is your current employment status?", "Cari məşğulluq vəziyyətiniz necədir?", "" },
            new string[]{ "131", "Employed", "İşlədi", "" },
            new string[]{ "132", "Self-Employed", "Öz-özünə işləyən", "" },
            new string[]{ "133", "Unemployed", "İşsizdir", "" },
            new string[]{ "134", "Student", "Tələbə", "" },
            new string[]{ "135", "How do you prefer to submit your resume?", "CV-ni necə təqdim etməyi üstün tutursunuz?", "" },
            new string[]{ "136", "Upload File", "Fayl yüklə", "" },
            new string[]{ "137", "Provide URL", "URL təmin edin", "" },
            new string[]{ "138", "Upload your resume", "CV-nizi yükləyin", "" },
            new string[]{ "139", "Choose file", "Faylı seçin", "" },
            new string[]{ "140", "Job Title", "Vəzifə", "" },
            new string[]{ "141", "Resume URL", "URL davam edin", "" },
            new string[]{ "142", "We provide high quality products with  affordable price.", "Biz münasib qiymətə yüksək keyfiyyətli dərmanlar təqdim edirik.", "" },
            new string[]{ "143", "Product Strategy", "Məhsul strategiyamız", "" },
            new string[]{ "144", "Dermatology", "Dermatologiya", "" },
            new string[]{ "145", "OTC", "Reseptsiz satılan", "" },
            new string[]{ "146", "Your Message", "messajiniz", "" },
            new string[]{ "147", "", "", "" },
            new string[]{ "148", "", "", "" },
            new string[]{ "149", "", "", "" },
            new string[]{ "140", "", "", "" }
        };
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment) 
        {
            _context = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;

            //foreach (var item in DictStr1)
            //{
            //    Dictionary itemD = new Dictionary();
            //    itemD.EN = item[1];
            //    itemD.AZ = item[2];
            //    itemD.RU = item[3];
            //    _context.Tbl_Dictionary.Add(itemD);
            //    _context.SaveChanges();
            //}

            //int kk = 0;

            int counter = 0;
            foreach (Dictionary item in _context.Tbl_Dictionary)
            {
                string[] itemstr = new string[4];
                itemstr[0] = (counter++).ToString();
                itemstr[1] = item.EN;
                itemstr[2] = item.AZ;
                itemstr[3] = item.RU;
                DictStr.Add(itemstr);
            }
        }
        private void Setlanguage(string lang)
        {
            try
            {
                ViewBag.DictStr = DictStr;
                if (lang == null)
                {
                    ViewBag.Language = "en";
                    ViewBag.LanguageID = 1;
                    return;
                }
                switch (lang.ToLower())
                {
                    case "az":
                        ViewBag.Language = "az";
                        ViewBag.LanguageID = 2;
                        break;
                    case "ru":
                        ViewBag.Language = "ru";
                        ViewBag.LanguageID = 3;
                        break;
                    default:
                        ViewBag.Language = "en";
                        ViewBag.LanguageID = 1;
                        break;
                }
            }
            catch (Exception)
            {
                ViewBag.Language = "en";
                ViewBag.LanguageID = 1;
            }
        }
        public IActionResult Index(string lang)
        {
            Setlanguage(lang);
            
            try
            {
                string kk = $"{ this.Request.PathBase }";
                ViewBag.PageURL = $"{this.Request.Scheme}://{this.Request.Host}/EN/Home/Index"; 
                ViewBag.PageID = "Index";
                //List <Slider> sliders = new List<Slider>();
                //foreach (Slider item in _context.Tbl_Sliders.Where(m => m.Lang == 1))
                //{
                //    sliders.Add(item);
                //}
                //ViewBag.sliders = sliders.ToList();
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult AboutUs(string lang)
        {
            Setlanguage(lang);

            ViewBag.PageURL = $"{this.Request.Scheme}://{this.Request.Host}/EN/Home/AboutUs"; 
            ViewBag.PageID = "AboutUs";
            return View();
        }
        public IActionResult Products(string lang)
        {
            Setlanguage(lang);
            return View();
        }
        public IActionResult PressCenter(string lang)
        {
            Setlanguage(lang);
            return View();
        }
        public IActionResult Partners(string lang)
        {
            Setlanguage(lang);
            ViewBag.PageID = "Partners";
            return View();
        }
        public IActionResult Career(string lang)
        {
            Setlanguage(lang);
            ViewBag.PageID = "Career";
            return View();
        }
        public IActionResult ContactUs(string lang)
        {
            Setlanguage(lang);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(string lang, [FromForm]vmdl_ContactUsIno vmdl_ContactUsIno)
        {
            string RefererStr = this.Request.Headers["Referer"];
            string ResumeStr = $"{this.Request.Scheme}://{this.Request.Host}/Uploads/"; // {this.Request.PathBase}";

            Setlanguage(lang);
            try
            {
                if (ModelState.IsValid)
                {
                    cls_MailManagement cls_MailManagement = new cls_MailManagement();
                    cls_MailManagement.To.Add(new cls_emailAccount("Koorosh.nosrati@live.com", "Kourosh Nosrati Heravi"));
                    cls_MailManagement.To.Add(new cls_emailAccount("valeh.farid@parlapharma.com", "Valeh Parla"));
                    cls_MailManagement.To.Add(new cls_emailAccount("info@parlapharma.com", "Info User of Parla Pharma"));
                    cls_MailManagement.Subject = "Parla Pharma Contact US Page : " + vmdl_ContactUsIno.Subject;
                    cls_MailManagement.Body = string.Format("Dear Info User : {6} Mr./Miss {0} Has Sent you an email through Contact Us Page. {6} His/Her Name : {1} " +
                                                "{6} Phone Number : {2} {6} Email : {3} {6} Subject : {4} {6} Message Body : {6} {5}", vmdl_ContactUsIno.FullName, vmdl_ContactUsIno.FullName, vmdl_ContactUsIno.PhoneNumber, vmdl_ContactUsIno.Email, vmdl_ContactUsIno.Subject, vmdl_ContactUsIno.MessageBody, Environment.NewLine );
                    cls_MailManagement.SendEmail();
                }
            }
            catch (Exception)
            {
                ;
            }
            return Redirect(RefererStr);
            //return View();
        }
        public IActionResult Applicationform(string lang)
        {
            Setlanguage(lang);
            ViewBag.ErrorMessage = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Applicationform(string lang, vmdl_ApplicationForm vmdl_ApplicationForm)
        {
            Setlanguage(lang);
            ViewBag.ErrorMessage = "";
            bool isSent = false;
            string ErrorMessageStr = "";
                 
            string AttachmentfilePath = "";
            bool hasAttachment = false;
            string ResumeStr = $"{this.Request.Scheme}://{this.Request.Host}/Uploads/"; // {this.Request.PathBase}";
            string uniqueResumeFileName = "";
            cls_UploadDownloadFiles cls_UploadDownloadFiles = new cls_UploadDownloadFiles();
            if (ModelState.IsValid)
            {
                if (vmdl_ApplicationForm.ResumeFile != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
                    uniqueResumeFileName = cls_UploadDownloadFiles.UploadedFile(
                        _webHostEnvironment.WebRootPath,
                        vmdl_ApplicationForm.ResumeFile);
                    AttachmentfilePath = Path.Combine(uploadsFolder, uniqueResumeFileName);
                    ResumeStr += uniqueResumeFileName;
                    hasAttachment = true;
                }
                else if (vmdl_ApplicationForm.ResumeURL != null && vmdl_ApplicationForm.ResumeURL.Length > 0)
                {
                    ResumeStr = vmdl_ApplicationForm.ResumeURL;
                }

                cls_MailManagement cls_MailManagement = new cls_MailManagement();
                cls_MailManagement.To.Add(new cls_emailAccount("Koorosh.nosrati@live.com", "Kourosh Nosrati Heravi"));
                cls_MailManagement.To.Add(new cls_emailAccount("valeh.farid@parlapharma.com", "Valeh Parla"));
                cls_MailManagement.To.Add(new cls_emailAccount("info@parlapharma.com", "Info User of Parla Pharma"));
                cls_MailManagement.Subject = "Parla Pharma Application Form Page" ;
                if (hasAttachment)
                    cls_MailManagement.Attachments.Add(AttachmentfilePath);
                cls_MailManagement.IsBodyHtml = true;
                cls_MailManagement.Body = string.Format(
                    "Dear Info User : {7} Mr./Miss {0} Has Sent you an email through Application Form Page.{7}" +
                    "His/Her Name : {0} {7} Phone Number : {1} {7} Email : {2} {7} Available Start Date : {3} {7} " +
                    "Emplyment Status : {4} {7} He/She Apply's for {5} {7} His/Her Resume : <a href=\"{6}\">Resume Link</a> {7}", 
                    vmdl_ApplicationForm.FirstName + " " + vmdl_ApplicationForm.LastName, 
                    vmdl_ApplicationForm.Phone, 
                    vmdl_ApplicationForm.Email,
                    vmdl_ApplicationForm.AvailableStartDate,
                    vmdl_ApplicationForm.EmploymentStatus,
                    vmdl_ApplicationForm.JobTitle,
                    ResumeStr,
                    "<br/>"); //Environment.NewLine

                ErrorMessageStr = cls_MailManagement.SendEmail();
                if (ErrorMessageStr == "OK")
                    isSent = true;
            }
            if (isSent)
                ViewBag.ErrorMessage = "Email is sent Succeessfully...";
            else
                ViewBag.ErrorMessage = "Error in sending Email... " + ErrorMessageStr;
            return View();
        }
        public IActionResult OurValues(string lang)
        {
            Setlanguage(lang);
            return View();
        }
    }
}