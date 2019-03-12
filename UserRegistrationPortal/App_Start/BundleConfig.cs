using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace UserRegistrationPortal.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // + Style Bundles +

            StyleBundle RegisterStyleBundle = new StyleBundle("~/Bundles/RegisterStyleBundle");
            RegisterStyleBundle.Include("~/Content/Registration/AccountRegister.css");
            bundles.Add(RegisterStyleBundle);

            StyleBundle HomeStyleBundle = new StyleBundle("~/Bundles/HomeStyleBundle");
            HomeStyleBundle.Include("~/Content/Home/HomeIndex.css");
            bundles.Add(HomeStyleBundle);

            StyleBundle LoginStyleBundle = new StyleBundle("~/Bundles/LoginStyleBundle");
            LoginStyleBundle.Include("~/Content/Login/AccountLogin.css");
            bundles.Add(LoginStyleBundle);

            StyleBundle UserStyleBundle = new StyleBundle("~/Bundles/UserStyleBundle");
            UserStyleBundle.Include("~/Content/User/UserIndex.css");
            bundles.Add(UserStyleBundle);

            StyleBundle LayoutStyleBundle = new StyleBundle("~/Bundles/LayoutStyleBundle");
            LayoutStyleBundle.Include("~/Content/Site.css");
            bundles.Add(LayoutStyleBundle);

            StyleBundle ErrorStyleBundle = new StyleBundle("~/Bundles/ErrorStyleBundle");
            ErrorStyleBundle.Include("~/Content/Error/NotFoud.css");
            bundles.Add(ErrorStyleBundle);

            // + Testing Purpose +
            StyleBundle _TestStyleBundle = new StyleBundle("~/Bundles/TestStyleBundle");
            _TestStyleBundle.Include("~/Content/_TestStyle/_TestUpdateStyle.css");
            bundles.Add(_TestStyleBundle);

            // + Script Bundles +

            ScriptBundle RegisterScriptBundle = new ScriptBundle("~/Bundles/RegisterScriptBundle");
            RegisterScriptBundle.Include("~/scripts/jquery-3.3.1.min.js",
                "~/scripts/jquery.validate.min.js",
                "~/scripts/CustomHelperMethods/CustomHelperMethods.js",
                "~/scripts/RegistrationScripts/Validation.js",
                "~/scripts/RegistrationScripts/CustomValidation.js",
                "~/scripts/RegistrationScripts/EventRegister.js",
                "~/scripts/RegistrationScripts/AddElement.js",
                "~/scripts/AjaxCalls/UserRegistrationPortalAjaxCall.js",
                "~/scripts/RegistrationScripts/Main.js",
                "~/scripts/additional-methods.min.js");
            bundles.Add(RegisterScriptBundle);

            ScriptBundle _TestScriptBundle = new ScriptBundle("~/Bundles/TestScript");
            _TestScriptBundle.Include("~/scripts/jquery-3.3.1.min.js");
            _TestScriptBundle.Include("~/scripts/AjaxCalls/UserRegistrationPortalAjaxCall.js");
            _TestScriptBundle.Include("~/scripts/UserControllerScripts/FormAction.js");
            _TestScriptBundle.Include("~/scripts/UserControllerScripts/ModelAction.js");
            _TestScriptBundle.Include("~/scripts/UserControllerScripts/EventRegister.js");
            _TestScriptBundle.Include("~/scripts/UserControllerScripts/Main.js");
            bundles.Add(_TestScriptBundle);

            BundleTable.EnableOptimizations = true;
        }
    }
}