using BlissRecruitment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlissRecruitment.DataAccess
{
    public class BlissRecruitmentDBContext : DbContext
    {
        #region Constructor
        public BlissRecruitmentDBContext(DbContextOptions<BlissRecruitmentDBContext> options)
        : base(options)
        {
        }
        #endregion

        #region Properties
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<ChoiceEntity> Choices { get; set; }

        #endregion
    }
}
