using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace _004WebAPIRouting
{
    public static class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services

        //    // Web API routes
        //    config.MapHttpAttributeRoutes();


        //    //School Route

        //    //Configure Multiple Routes
        //    // school route
        //    //config.Routes.MapHttpRoute(
        //    //    name: "School",
        //    //    routeTemplate: "api/myschool/{id}",
        //    //    defaults: new { controller = "SchoolController", id = RouteParameter.Optional },
        //    //    constraints: new { id = "/d+" }
        //    //);



        //    //Default Route
        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );


        //    //Alternative -> Default Route
        //    //IHttpRoute defaultRoute = config.Routes.CreateRoute("api/{controller}/{id}",
        //    //    new { id = RouteParameter.Optional }, null);
        //}



        //Routing has three main phases:
        //  -   Matching the URI to a route template.
        //  -   Selecting a controller.
        //  -   Selecting an action.


        // Eine Routenvorlage ähnelt einem URI-Pfad, kann jedoch Platzhalterwerte enthalten, die in geschweiften Klammern angegeben sind:
        // "api/{controller}/public/{category}/{id}"

        //Wenn Sie eine Route erstellen, können Sie Standardwerte für einige oder alle Platzhalter angeben:
        //defaults: new { category = "all" }

        //Sie können auch Einschränkungen angeben, die einschränken, wie ein URI-Segment mit einem Platzhalter übereinstimmen kann:
        //constraints: new { id = @"\d+" }   // Only matches if "id" is one or more digits.


        //DEFAULT-ROUTE
        //Wenn Sie Standardeinstellungen angeben, stimmt die Route mit einem URI überein, bei dem diese Segmente fehlen. Beispielsweise:



        //Die URIs http://localhost/api/products/all und http://localhost/api/products stimmen mit der vorhergehenden Route überein. 
        //In der letzteren URI wird dem fehlenden {Kategorie} -Segment der Standardwert all zugewiesen.


        // Route Dictionary
        // Wenn das Framework eine Übereinstimmung für einen URI findet, erstellt es ein Dictonary, das den Wert für jeden Platzhalter enthält.
        // Die Schlüssel sind die Platzhalternamen ohne die geschweiften Klammern. Die Werte werden aus dem URI-Pfad oder aus den Standardeinstellungen übernommen. 
        // Das Dictionary wird im IHttpRouteData-Objekt gespeichert. Während dieser Routenanpassungsphase werden die speziellen Platzhalter "{controller}" und "{action}" wie die 
        // anderen Platzhalter behandelt.Sie werden einfach mit den anderen Werten im Dictionary gespeichert.Ein Standardwert kann den Sonderwert RouteParameter.Optional haben. 
        // Wenn einem Platzhalter dieser Wert zugewiesen wird, wird der Wert nicht zum Routen-Dictionary hinzugefügt.
        // Beispielsweise:
        //-------------------------------------------------------------------------------------------------------------
        //routes.MapHttpRoute(
        //name: "DefaultApi",
        //routeTemplate: "api/{controller}/{category}",
        //defaults: new { category = "all" }
        //);

        //Beispiel1:
        //https://localhost:1234/api/products
        //Controller = products
        //Category = all

        //Beispiel2:
        //https://localhost:1234/api/products/toys/123
        //Controller = products
        //Category = toys
        //id = 123
        //-------------------------------------------------------------------------------------------------------------

        //routes.MapHttpRoute(
        //    name: "Root",
        //    routeTemplate: "api/root/{id}",
        //    defaults: new { controller = "customers", id = RouteParameter.Optional}
        //);

        //Beispiel:
        //https://localhost:1234/api/root/8
        //Controller = customer
        //Id = 8
        //--------------------------------------------------------------------------------------------------------------







        //https://www.tutorialsteacher.com/webapi/web-api-routing
        //https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/routing-in-aspnet-web-api

        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services

        //    // Web API routes
        //    config.MapHttpAttributeRoutes();


        //    //The MapHttpRoute() extension method erstellt intern eine Instance von IHttpRoute
        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );
        //}

        //Alternative Implementierung
        //public static void Register(HttpConfiguration config)
        //{
        //    config.MapHttpAttributeRoutes();

        //    // define route
        //    IHttpRoute defaultRoute = config.Routes.CreateRoute("api/{controller}/{id}",
        //                                        new { id = RouteParameter.Optional }, null);

        //    // Add route
        //    config.Routes.Add("DefaultApi", defaultRoute);
        //}
        //
        public static void Register(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();

            //Configure Multiple Routes
            // school route
            config.Routes.MapHttpRoute(
                name: "School",
                routeTemplate: "api/myschool/{id}",
                defaults: new { controller = "school", id = RouteParameter.Optional },
                constraints: new { id = "/d+" }
            );


            //The MapHttpRoute() extension method erstellt intern eine Instance von IHttpRoute
            // default route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            }



        #region Controller Selection Mechanismus
        //Controller auswählen
        //Die Controller-Auswahl wird von der IHttpControllerSelector.SelectController-Methode übernommen.
        //Diese Methode verwendet eine HttpRequestMessage-Instanz und gibt einen HttpControllerDescriptor zurück. 
        //Die Standardimplementierung wird von der DefaultHttpControllerSelector-Klasse bereitgestellt. 
        //Diese Klasse verwendet einen einfachen Algorithmus:Suchen Sie im Routen-Dictionary nach dem Schlüssel "Controller".
        //Nehmen Sie den Wert für diesen Schlüssel und hängen Sie die Zeichenfolge "Controller" an, um den Namen des Controllertyps zu erhalten.
        //Suchen Sie nach einem Web-API-Controller mit diesem Typnamen.
        //Wenn das Routen-Dictionary beispielsweise das Schlüssel-Wert-Paar "controller" = "products" enthält, lautet der Controller-Typ "ProductsController". 
        //Wenn es keinen übereinstimmenden Typ oder mehrere Übereinstimmungen gibt, gibt das Framework einen Fehler an den Client zurück.

        //In Schritt 3 verwendet DefaultHttpControllerSelector die IHttpControllerTypeResolver-Schnittstelle, um die Liste der Web-API-Controllertypen abzurufen. 
        //Die Standardimplementierung von IHttpControllerTypeResolver gibt alle öffentlichen Klassen zurück, die 
        //(a) IHttpController implementieren, (b) nicht abstrakt sind und (c) einen Namen haben, der mit "Controller" endet.


        //Action Methode Auswahlmechanismus
        //Nach Auswahl des Controllers wählt das Framework die Aktion durch Aufrufen der IHttpActionSelector.SelectAction-Methode aus. 
        //Diese Methode verwendet einen HttpControllerContext und gibt einen HttpActionDescriptor zurück.
        //Die Standardimplementierung wird von der ApiControllerActionSelector-Klasse bereitgestellt. 
        //Um eine Aktion auszuwählen, wird Folgendes angezeigt:Die HTTP-Methode der Anforderung.
        //Der Platzhalter "{action}" in der Routenvorlage, falls vorhanden.Die Parameter der Aktionen auf der Steuerung.
        //Bevor wir uns den Auswahlalgorithmus ansehen, müssen wir einige Dinge über Controller-Aktionen verstehen.
        //Welche Methoden auf dem Controller gelten als "Aktionen"? Bei der Auswahl einer Aktion berücksichtigt das Framework nur öffentliche Instanzmethoden auf dem Controller. 
        //Außerdem werden Methoden mit "speziellen Namen" (Konstruktoren, Ereignisse, Operatorüberladungen usw.) 
        //und von der ApiController-Klasse geerbte Methoden ausgeschlossen.

        //HTTP-Methoden.
        //Das Framework wählt nur Aktionen aus, die der HTTP-Methode der Anforderung entsprechen und wie folgt festgelegt werden:
        //Sie können die HTTP-Methode mit einem Attribut angeben: AcceptVerbs, HttpDelete, HttpGet, HttpHead, HttpOptions, HttpPatch, HttpPost oder HttpPut.
        //Wenn der Name der Controller-Methode mit "Get", "Post", "Put", "Delete", "Head", "Options" oder "Patch" beginnt, 
        //unterstützt die Aktion diese HTTP-Methode gemäß Konvention. Ist dies nicht der Fall, unterstützt die Methode POST.
        #endregion


        #region
        //Parameter Binding
        //Parameterbindungen.
        //Bei einer Parameterbindung erstellt die Web-API einen Wert für einen Parameter. 
        //Hier ist die Standardregel für die Parameterbindung:
        // - Einfache Typen werden aus dem URI übernommen. ->Zu den einfachen Typen gehören alle primitiven.NET Framework-Typen sowie DateTime, Decimal, Guid, String und TimeSpan.
        // - Komplexe Typen werden aus dem Anforderungshauptteil (request body) entnommen.
        // - Für jede Aktion kann höchstens ein Parameter den Anforderungshauptteil lesen.
        //



        //Es ist möglich, die Standardbindungsregeln zu überschreiben. Link -> https://docs.microsoft.com/en-us/archive/blogs/jmstall/webapi-parameter-binding-under-the-hood


        //Vor diesem Hintergrund finden Sie hier den Aktionsauswahlalgorithmus.
        //1.) Erstellen Sie eine Liste aller Aktionen auf dem Controller, die der HTTP-Anforderungsmethode entsprechen.
        //2.) Wenn das Routen-Dictionary einen "Aktions" -Eintrag enthält, entfernen Sie Aktionen, deren Name nicht mit diesem Wert übereinstimmt.
        //3.) Versuchen Sie, die Aktionsparameter wie folgt mit dem URI abzugleichen:
        //      a) Rufen Sie für jede Aktion eine Liste der Parameter ab, die ein einfacher Typ sind, wobei die Bindung den Parameter vom URI abruft. Optionale Parameter ausschließen.
        //      b) Versuchen Sie in dieser Liste, eine Übereinstimmung für jeden Parameternamen zu finden, entweder im Routen-Dictionary oder in der URI-Abfragezeichenfolge.
        //         Übereinstimmungen unterscheiden nicht zwischen Groß- und Kleinschreibung und hängen nicht von der Parameterreihenfolge ab.
        //      c) Wählen Sie eine Aktion aus, bei der jeder Parameter in der Liste mit der URI übereinstimmt.
        //      d) Wenn mehr als eine Aktion diese Kriterien erfüllt, wählen Sie die Aktion mit den meisten Parameterübereinstimmungen aus.
        // 4.)  Ignorieren Sie Aktionen mit dem Attribut [NonAction].



        // Schritt 3 ist wahrscheinlich der verwirrendste. 
        // Die Grundidee ist, dass ein Parameter seinen Wert entweder vom URI, vom Anforderungshauptteil oder von einer benutzerdefinierten Bindung erhalten kann. 
        // Für Parameter, die vom URI stammen, möchten wir sicherstellen, dass der URI tatsächlich einen Wert für diesen Parameter enthält, entweder im Pfad (über das Routen-Dictionary) oder in der Abfragezeichenfolge.
        #endregion
    }
}
