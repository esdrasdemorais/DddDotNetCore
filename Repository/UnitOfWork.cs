using System;
using Microsoft.EntityFrameworkCore;

namespace DddDotNetCore.Repository
{
    public abstract class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;

        /*Sample Specific IRepository:
	    private ILayoutRepository layoutRepository;

        private ICompanyRepository companyRepository;

        private IFileLayoutRepository fileLayoutRepository;

        private IFieldRepository fieldRepository;

        private IHeaderRepository headerRepository;

        private IDetailRepository detailRepository;

        private ITrailerRepository trailerRepository;*/

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        // public UnitOfWork()
        // {
        //     this.context = new AppDbContext(null);
        // }

        /* Sample Specific IRepository Properties:
	public ILayoutRepository LayoutRepository
        {
            get
            {
                return this.layoutRepository = this.layoutRepository??
                    new LayoutRepository(context);
            }
        }

        public ICompanyRepository CompanyRepository
        {
            get
            {
                return this.companyRepository = this.companyRepository??
                    new CompanyRepository(context);
            }
        }

        public IFileLayoutRepository FileLayoutRepository
        {
            get
            {
                return this.fileLayoutRepository = this.fileLayoutRepository??
                    new FileLayoutRepository(
                        context, HeaderRepository, 
                        DetailRepository, TrailerRepository
                    );
            }
        }

        public IHeaderRepository HeaderRepository
        {
            get
            {
                return this.headerRepository = this.headerRepository??
                    new HeaderRepository(context, FieldRepository);
            }
        }

        public IDetailRepository DetailRepository
        {
            get
            {
                return this.detailRepository = this.detailRepository??
                    new DetailRepository(context, FieldRepository);
            }
        }

        public ITrailerRepository TrailerRepository
        {
            get
            {
                return this.trailerRepository = this.trailerRepository??
                    new TrailerRepository(context, FieldRepository);
            }
        }

        public IFieldRepository FieldRepository
        {
            get
            {
                return this.fieldRepository = this.fieldRepository??
                    new FieldRepository(context);
            }
        }*/

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
