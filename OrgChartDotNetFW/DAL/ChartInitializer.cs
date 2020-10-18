using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OrgChartDotNetFW.Models;

namespace OrgChartDotNetFW.DAL
{
    public class ChartInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OrgChartContext>
    {
        protected override void Seed(OrgChartContext context)
        {
            var nodes =new List<Node>
            {
                new Node{Id="top-management", Tags=new string[]{="top-management" } },
                new Node{ Id="hr-team", Pid="top-management", Tags=new string[]{"hr-team", "department"}, Name="HR department" },
                new Node{ Id="it-team", Pid="top-management", Tags=new string[]{"it-team", "department" }, Name="IT department" },
                new Node { Id="sales-team", Pid="top-management", Tags=new string[]{"sales-team", "department" }, Name="Sales department" },

                new Node { Id="1", Stpid="top-management", Name="Nicky Phillips", Title="CEO", Img="https=//cdn.balkan.app/shared/1.jpg", Tags=new string[]{"seo-menu"} },
                new Node { Id="2", Pid="1", Name="Rowan Hall", Title="Shareholder (51%)", Img="https=//cdn.balkan.app/shared/2.jpg", Tags=new string[]{"menu-without-add"} },
                new Node { Id="3", Pid="1", Name="Danni Anderson", Title="Shareholder (49%)", Img="https=//cdn.balkan.app/shared/3.jpg", Tags=new string[]{"menu-without-add"} },

                new Node { Id="4", Stpid="hr-team", Name="Jordan Harris", Title="HR Manager", Img="https=//cdn.balkan.app/shared/4.jpg" },
                new Node { Id="5", Pid="4", Name="Emerson Adams", Title="Senior HR", Img="https=//cdn.balkan.app/shared/5.jpg" },
                new Node { Id="6", Pid="4", Name="Kai Morgan", Title="Junior HR", Img="https=//cdn.balkan.app/shared/6.jpg" },

                new Node { Id="7", Stpid="it-team", Name="Cory Robbins", Title="Core Team Lead", Img="https=//cdn.balkan.app/shared/7.jpg" },
                new Node { Id="8", Pid="7", Name="Billie Roach", Title="Backend Senior Developer", Img="https=//cdn.balkan.app/shared/8.jpg" },
                new Node { Id="9", Pid="7", Name="Maddox Hood", Title="C# Developer", Img="https=//cdn.balkan.app/shared/9.jpg" },
                new Node { Id="10", Pid="7", Name="Sam Tyson", Title="Backend Junior Developer", Img="https=//cdn.balkan.app/shared/10.jpg" },

                new Node { Id="11", Stpid="it-team", Name="Lynn Fleming", Title="UI Team Lead", Img="https=//cdn.balkan.app/shared/11.jpg" },
                new Node { Id="12", Pid="11", Name="Jo Baker", Title="JS Developer", Img="https=//cdn.balkan.app/shared/12.jpg" },
                new Node { Id="13", Pid="11", Name="Emerson Lewis", Title="Graphic Designer", Img="https=//cdn.balkan.app/shared/13.jpg" },
                new Node { Id="14", Pid="11", Name="HaIden Atkinson", Title="UX Expert", Img="https=//cdn.balkan.app/shared/14.jpg" },
                new Node { Id="15", Stpid="sales-team", Name="Tyler Chavez", Title="Sales Manager", Img="https=//cdn.balkan.app/shared/15.jpg" },
                new Node { Id="16", Pid="15", Name="Raylee Allen", Title="Sales", Img="https=//cdn.balkan.app/shared/16.jpg" },
                new Node { Id="17", Pid="15", Name="Kris Horne", Title="Sales Guru", Img="https=//cdn.balkan.app/shared/8.jpg" },
                new Node { Id="18", Pid="top-management", Name="Leslie Mcclain", Title="Personal assistant", Img="https=//cdn.balkan.app/shared/9.jpg", Tags=new string[]{=["assistant", "menu-without-add"] }
            }
        }
    }
}