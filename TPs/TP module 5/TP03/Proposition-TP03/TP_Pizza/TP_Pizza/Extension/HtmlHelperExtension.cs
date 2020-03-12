using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP_Pizza.Extension
{
    public static class HtmlHelperExtension
    {
        /// <summary>
        /// Permet de générer les balises html nécessaire pour un bouton de formulaire de type Submit
        /// </summary>
        /// <typeparam name="TModel">Le model de la vue</typeparam>
        /// <param name="html"></param>
        /// <param name="libelle">Le libellé du bouton</param>
        /// <returns></returns>
        public static MvcHtmlString CustomSubmit<TModel>(this HtmlHelper<TModel> html, string libelle)
        {
            return new MvcHtmlString($"<div class=\"form-group\"><div class=\"col-md-offset-2 col-md-10\"><input type=\"submit\" value=\"{libelle}\" class=\"btn btn-default\" /></div></div>");
        }
    }
}