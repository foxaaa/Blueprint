using Blueprint.UAS.Entity;
using Blueprint.UAS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint.UAS.BLL
{
    public class OrgService : UASBaseService<Org>, IOrgService
    {
        public void test()
        {
            //Empl empl = new Empl() { Name = "徐峰", Code = "xufeng" };
            //Dept dept = new Dept() { Name = "xx部门", Code="123" };
            //dept.Empl.Add(empl);
            //Org org = new Org();
            //org.Name = "xx公司";
            //org.Code = "abc";
            //org.Dept.Add(dept);
            //AddEntity(org);

            RuleService ruleService = new RuleService();

            Auth auth1 = new Auth() { Code = "001", Description = "test1" };
            Auth auth2 = new Auth() { Code = "002", Description = "test2" };

            Rule rule = new Rule(){ Code="001",Name="测试员"};
            rule.Auth.Add(auth1);
            rule.Auth.Add(auth2);

            ruleService.AddEntity(rule);
        }
    }
}
