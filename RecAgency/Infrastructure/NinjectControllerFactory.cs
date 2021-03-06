﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Ninject;
using System.Web.Mvc;
using System.Configuration;
using RecAgency.Abstract;
using RecAgency.Concrete;
using RecAgency.Entities;

namespace RecAgency.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<ISummaryRepository>().To<EFSummaryRepository>();
            ninjectKernel.Bind<IVacancyRepository>().To<EFVacancyRepository>();
            ninjectKernel.Bind<ISummaryAndVacancyRepository>().To<EFSummaryAndVacancyRepository>();
        }
    }
}