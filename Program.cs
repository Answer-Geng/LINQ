using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee("001","Mike",32,new DateTime(2016,2,20),Sex.Male,Department.IT,200000,new string[] { "swimming","shopping"}),
                new Employee("002","Jack",38,new DateTime(2007,5,12),Sex.Male,Department.HR,409989,new string[] { "reading"}),
                new Employee("003","Adolph",25,new DateTime(2017,3,23),Sex.Male,Department.IT,100000,new string[] { "play computer games","watch TV","listen to music"}),
                new Employee("004","Antony",30,new DateTime(2010,11,20),Sex.Male,Department.FD,320000, new string[] { "play chess","run"}),
                new Employee("005","Asa",28,new DateTime(2014,10,10),Sex.Female,Department.FD,120000,new string[] { "shopping"}),
                new Employee("006","Bernie",31,new DateTime(2008,4,5),Sex.Male,Department.PD,220000,new string[] { "play basketball"}),
                new Employee("007","Carl",26,new DateTime(2015,1,30),Sex.Male,Department.QC,100000,new string[] { "play chess","go fishing"}),
                new Employee("008","Duncan",30,new DateTime(2009,6,9),Sex.Male,Department.MD,250000,new string[] { "play computer games"}),
                new Employee("009","Aimee",24,new DateTime(2017,1,20),Sex.Female,Department.HR,80000,new string[] { "reading","run"}),
                new Employee("010","Cassie",31,new DateTime(2014,3,3),Sex.Female,Department.IT,350000,new string[] { "watch TV" })
            };

            #region 筛选操作符   Where、OfType<TResult>
            //查询年龄大于30岁，IT或HR部门所有员工的编号及姓名
            //var filter = from r in employees
            //             where r.Age > 30 && (r.Department == Department.IT.ToString() || r.Department == Department.HR.ToString())
            //             select r;

            //foreach (var item in filter)
            //{
            //    Console.WriteLine("EmployId: " + item.EmployeeId + " EmployeeName: " + item.EmployeeName);
            //}

            //******************************Output*******************************
            //EmployId: 001 EmployeeName: Mike
            //EmployId: 002 EmployeeName: Jack
            //EmployId: 010 EmployeeName: Cassie
            //*******************************************************************

            //筛选出指定数组中所有int类型的元素
            //object[] data = { "One", 2, 3, "Four", "Five", 6 };
            //var typeFilter = data.OfType<int>();
            //foreach (var item in typeFilter)
            //{
            //    Console.WriteLine(item);
            //}

            //******************************Output*******************************
            //2
            //3
            //6
            //*******************************************************************

            #endregion

            #region 投射操作符   Select、SelectMany
            //查找个人爱好中有reading的员工的姓名
            //var doubleFrom = from r in employees
            //                 from h in r.Hobby
            //                 where h == "reading"
            //                 select r.EmployeeName;
            //foreach (var item in doubleFrom)
            //{
            //    Console.WriteLine(item);
            //}

            //******************************Output*******************************
            //Jack
            //Aimee
            //*******************************************************************
            //--------------------------强势分隔符--------------------------------
            //使用SelectMany扩展方法返回个人爱好中有reading的员工的姓名
            //var selectMany = employees.
            //    SelectMany(r => r.Hobby,
            //    (r, h) => new { Employee = r, Hobby = h }).
            //    Where(r => r.Hobby == "reading").
            //    Select(r => r.Employee.EmployeeName);
            //foreach (var item in selectMany)
            //{
            //    Console.WriteLine(item);
            //}
            //******************************Output*******************************
            //Jack
            //Aimee
            //*******************************************************************
            #endregion

            #region 排序操作符   OrderBy、ThenBy、OrderByDescending、ThenByDescending、Reverse
            //按照年龄从大到小排序，如果年龄相同，则按照员工编号正向排序，输出员工的编号、姓名、年龄,
            //var orderBy = from o in employees
            //              orderby o.Age descending, o.EmployeeId
            //              select o;
            //foreach (var item in orderBy)
            //{
            //    Console.WriteLine("EmployeeId: " + item.EmployeeId + " EmployeeName:" + item.EmployeeName + " Age:" + item.Age);
            //}

            //******************************Output*******************************
            //EmployeeId: 002 EmployeeName: Jack Age:38
            //EmployeeId: 001 EmployeeName: Mike Age:32
            //EmployeeId: 006 EmployeeName: Bernie Age:31
            //EmployeeId: 010 EmployeeName: Cassie Age:31
            //EmployeeId: 004 EmployeeName: Antony Age:30
            //EmployeeId: 008 EmployeeName: Duncan Age:30
            //EmployeeId: 005 EmployeeName: Asa Age:28
            //EmployeeId: 007 EmployeeName: Carl Age:26
            //EmployeeId: 003 EmployeeName: Adolph Age:25
            //EmployeeId: 009 EmployeeName: Aimee Age:24
            //*******************************************************************

            //--------------------------强势分隔符--------------------------------

            //使用ThenBy扩展方法实现年龄相同，按员工编号正向排序
            //var thenBy = employees
            //             .OrderByDescending(t => t.Age)
            //             .ThenBy(t => t.EmployeeId)
            //             .Select(t => "EmployeeId: " + t.EmployeeId + " EmployeeName:" + t.EmployeeName + " Age:" + t.Age);
            //foreach (var item in thenBy)
            //{
            //    Console.WriteLine(item);
            //}

            //******************************Output*******************************
            //EmployeeId: 002 EmployeeName: Jack Age:38
            //EmployeeId: 001 EmployeeName: Mike Age:32
            //EmployeeId: 006 EmployeeName: Bernie Age:31
            //EmployeeId: 010 EmployeeName: Cassie Age:31
            //EmployeeId: 004 EmployeeName: Antony Age:30
            //EmployeeId: 008 EmployeeName: Duncan Age:30
            //EmployeeId: 005 EmployeeName: Asa Age:28
            //EmployeeId: 007 EmployeeName: Carl Age:26
            //EmployeeId: 003 EmployeeName: Adolph Age:25
            //EmployeeId: 009 EmployeeName: Aimee Age:24
            //*******************************************************************

            //按照年龄从大到小排序后再反转元素的顺序
            //var reverse = employees
            //    .OrderByDescending(r => r.Age)
            //    .Reverse()
            //    .Select(r => "EmployeeId: " + r.EmployeeId + " EmployeeName:" + r.EmployeeName + " Age:" + r.Age);
            //foreach (var item in reverse)
            //{
            //    Console.WriteLine(item);
            //}

            //******************************Output*******************************
            //EmployeeId: 009 EmployeeName: Aimee Age:24
            //EmployeeId: 003 EmployeeName: Adolph Age:25
            //EmployeeId: 007 EmployeeName: Carl Age:26
            //EmployeeId: 005 EmployeeName: Asa Age:28
            //EmployeeId: 008 EmployeeName: Duncan Age:30
            //EmployeeId: 004 EmployeeName: Antony Age:30
            //EmployeeId: 010 EmployeeName: Cassie Age:31
            //EmployeeId: 006 EmployeeName: Bernie Age:31
            //EmployeeId: 001 EmployeeName: Mike Age:32
            //EmployeeId: 002 EmployeeName: Jack Age:38
            //*******************************************************************
            #endregion

            #region 连接操作符   Join、GroupJoin
            //List<DepartmentInfo> deparmentInfo = new List<DepartmentInfo>()
            //{
            //    new DepartmentInfo("001","HR","Oliver"),
            //    new DepartmentInfo("002","IT","Oscar"),
            //    new DepartmentInfo("003","PD","ELLA"),
            //    new DepartmentInfo("004","FD","Alice"),
            //    new DepartmentInfo("005","QC","Kai")
            //};

            //List<OutstandingTeam> outstandingTeams = new List<OutstandingTeam>()
            //{
            //    new OutstandingTeam(2010,"IT"),
            //    new OutstandingTeam(2011,"FD"),
            //    new OutstandingTeam(2012,"HR"),
            //    new OutstandingTeam(2013,"IT"),
            //    new OutstandingTeam(2014,"QC"),
            //    new OutstandingTeam(2015,"HR"),
            //    new OutstandingTeam(2016,"HR"),
            //    new OutstandingTeam(2017,"MD")
            //};

            //查询员工的姓名，部门以及该部门的总监
            //var join = from j in employees
            //           join d in deparmentInfo
            //           on j.Department equals d.DepartmentName
            //           select new
            //           {
            //               j.EmployeeName,
            //               j.Department,
            //               d.Director
            //           };
            //foreach (var item in join)
            //{
            //    Console.WriteLine("EmployeeName: " + item.EmployeeName + " Department:" + item.Department + " Director:" + item.Director);
            //}

            //******************************Output*******************************
            //EmployeeName: Mike Department:IT Director:Oscar
            //EmployeeName: Jack Department:HR Director:Oliver
            //EmployeeName: Adolph Department:IT Director:Oscar
            //EmployeeName: Antony Department:FD Director:Alice
            //EmployeeName: Asa Department:FD Director:Alice
            //EmployeeName: Bernie Department:PD Director:ELLA
            //EmployeeName: Carl Department:QC Director:Kai
            //EmployeeName: Aimee Department:HR Director:Oliver
            //EmployeeName: Cassie Department:IT Director:Oscar
            //*******************************************************************

            //查询员工的姓名，部门以及该部门的总监,若匹配不到该部门信息，Director返回N/A
            //var leftjoin = from j in employees
            //               join d in deparmentInfo
            //               on j.Department equals d.DepartmentName into jd
            //               from d in jd.DefaultIfEmpty()
            //               select new
            //               {
            //                   j.EmployeeName,
            //                   j.Department,
            //                   Director = d == null ? "N/A" : d.Director
            //               };
            //foreach (var item in leftjoin)
            //{
            //    Console.WriteLine("EmployeeName: " + item.EmployeeName + " Department:" + item.Department + " Director:" + item.Director);
            //}

            //******************************Output*******************************
            //EmployeeName: Mike Department:IT Director:Oscar
            //EmployeeName: Jack Department:HR Director:Oliver
            //EmployeeName: Adolph Department:IT Director:Oscar
            //EmployeeName: Antony Department:FD Director:Alice
            //EmployeeName: Asa Department:FD Director:Alice
            //EmployeeName: Bernie Department:PD Director:ELLA
            //EmployeeName: Carl Department:QC Director:Kai
            //EmployeeName: Duncan Department:MD Director:N/A
            //EmployeeName: Aimee Department:HR Director:Oliver
            //EmployeeName: Cassie Department:IT Director:Oscar
            //*******************************************************************

            //查找每个部门获得杰出团队的年份
            //var groupJoin = from d in deparmentInfo
            //                join o in outstandingTeams on d.DepartmentName equals o.Department into g
            //                select new
            //                {
            //                    DepartmentName = d.DepartmentName,
            //                    Years = g 
            //                };
            //foreach (var item in groupJoin)
            //{
            //    Console.WriteLine("Department:" + item.DepartmentName);

            //    if (item.Years.Count() == 0)
            //    {
            //        Console.WriteLine("Never won the award");
            //    }
            //    foreach (var champions in item.Years)
            //    {
            //        Console.WriteLine(champions.Year);
            //    }

            //}

            //******************************Output*******************************
            //Department: HR
            //2012
            //2015
            //2016
            //Department: IT
            //2010
            //2013
            //Department: PD
            // Never won the award
            // Department:FD
            //2011
            //Department: QC
            //2014
            //*******************************************************************

            #endregion

            #region 组合操作符   GroupBy、ToLookup
            //查询每个部门及人数
            //var groupBy = from e in employees
            //              group e by e.Department into g
            //              select new
            //              {
            //                  g.Key,
            //                  Count = g.Count()
            //              };
            //foreach (var item in groupBy)
            //{
            //    Console.WriteLine("Department: " + item.Key + " Count: " + item.Count);
            //}

            //******************************Output*******************************
            //Department: IT Count: 3
            //Department: HR Count: 2
            //Department: FD Count: 2
            //Department: PD Count: 1
            //Department: QC Count: 1
            //Department: MD Count: 1
            //*******************************************************************

            //使用ToLookup实现爱好阅读的员工姓名
            //var toLookup = (from e in employees
            //                from h in e.Hobby
            //                select new
            //                {
            //                    Hobby = h,
            //                    Name = e.EmployeeName
            //                }).ToLookup(he => he.Hobby, he => he.Name);

            //if (toLookup.Contains("reading"))
            //{
            //    foreach (var item in toLookup["reading"])
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            //******************************Output*******************************
            //Jack
            //Aimee
            //*******************************************************************

            #endregion

            #region 限定操作符   Any、All、Contains
            //是否有小于20岁的员工
            //bool any = employees.Any(r => r.Age < 20);
            //Console.WriteLine(any);

            //******************************Output*******************************
            //False
            //*******************************************************************

            //是否所有员工都大于20岁
            //bool all = employees.All(r => r.Age > 20);
            //Console.WriteLine(all);

            //******************************Output*******************************
            //True
            //*******************************************************************

            //员工列表中是否包含david
            //Employee david = new Employee("011", "David", 28, new DateTime(2017, 5, 21), Sex.Male, Department.IT, 100000, new string[] { "run" });
            //employees.Add(david);
            //bool contains = employees.Contains(david);
            //Console.WriteLine(contains);

            //******************************Output*******************************
            //True
            //*******************************************************************

            #endregion

            #region 分区操作符   Take、Skip、TakeWhile、SkipWhile
            //跳过薪水最高的5位，查询剩余部分薪水最高的员工姓名及薪水
            //var skip = (from e in employees
            //            orderby e.Salary descending
            //            select e).Skip(5).Take(1);
            //foreach (var item in skip)
            //{
            //    Console.WriteLine("EmployeeName: " + item.EmployeeName + " Salary: " + item.Salary);
            //}

            //******************************Output*******************************
            //EmployeeName: Mike Salary: 200000
            //*******************************************************************

            //取集合中满足条件salary大于1000000之前的所有员工的姓名和薪水
            //var takeWhile = (from e in employees
            //                 select e).TakeWhile(r => r.Salary > 100000);
            //foreach (var item in takeWhile)
            //{
            //    Console.WriteLine("EmployeeName: " + item.EmployeeName + " Salary: " + item.Salary);
            //}

            //******************************Output*******************************
            //EmployeeName: Mike Salary: 200000
            //EmployeeName: Jack Salary: 409989
            //*******************************************************************

            //跳过集合中满足条件salary大于100000的元素，当条件不成立时返回剩余的所有元素
            //var skipWhile = (from e in employees
            //                 select e).SkipWhile(r => r.Salary > 100000);
            //foreach (var item in skipWhile)
            //{
            //    Console.WriteLine("EmployeeName: " + item.EmployeeName + " Salary: " + item.Salary);
            //}

            //******************************Output*******************************
            //EmployeeName: Adolph Salary: 100000
            //EmployeeName: Antony Salary: 320000
            //EmployeeName: Asa Salary: 120000
            //EmployeeName: Bernie Salary: 220000
            //EmployeeName: Carl Salary: 100000
            //EmployeeName: Duncan Salary: 250000
            //EmployeeName: Aimee Salary: 80000
            //EmployeeName: Cassie Salary: 350000
            //*******************************************************************

            #endregion

            #region Set操作符  Distinct、Union、Intersect、Except、Zip
            //给所有员工的薪水排序，去掉重复的
            //var distinct = (from e in employees
            //                orderby e.Salary 
            //                select e.Salary).Distinct();

            //foreach (var item in distinct)
            //{
            //    Console.WriteLine(item);
            //}

            //******************************Output*******************************
            //80000
            //100000
            //120000
            //200000
            //220000
            //250000
            //320000
            //350000
            //409989
            //*******************************************************************

            var startWithA = (from e in employees
                              where e.EmployeeName.StartsWith("A")
                              select e).ToList();

            var endWithE = (from e in employees
                            where e.EmployeeName.ToUpper().EndsWith("E")
                            select e).ToList();

            //查询两个集合的并集
            //var union = startWithA.Union(endWithE);
            //foreach (var item in union)
            //{
            //    Console.WriteLine(item.EmployeeName);
            //}

            //******************************Output*******************************
            //Adolph
            //Antony
            //Asa
            //Aimee
            //Mike
            //Bernie
            //Cassie
            //*******************************************************************

            //--------------------------强势分隔符--------------------------------

            //查询两个集合的交集
            //var intersect = startWithA.Intersect(endWithE);
            //foreach (var item in intersect)
            //{
            //    Console.WriteLine(item.EmployeeName);
            //}

            //******************************Output*******************************
            //Aimee
            //*******************************************************************

            //--------------------------强势分隔符--------------------------------

            //查询两个集合的差集
            //var except = startWithA.Except(endWithE);
            //foreach (var item in except)
            //{
            //    Console.WriteLine(item.EmployeeName);
            //}

            //******************************Output*******************************
            //Adolph
            //Antony
            //Asa
            //*******************************************************************

            //把两个集合中对应的项的姓名合并起来
            //var zip = startWithA.Zip(endWithE, (first, second) => first.EmployeeName + "+" + second.EmployeeName);
            //foreach (var item in zip)
            //{
            //    Console.WriteLine(item);
            //}

            //******************************Output*******************************
            //Adolph+Mike
            //Antony+Bernie
            //Asa+Aimee
            //Aimee+Cassie
            //*******************************************************************

            #endregion

            #region 元素操作符   First、FirstOrDefault、Last、LastOrDefault、ElementAt、ElementAtOrDefault、Single、SingleOrDefault
            //查询年龄大于30岁的第一位员工的姓名
            //var first = (from e in employees
            //             orderby e.Age
            //             select e).First(r => r.Age > 30);
            //Console.WriteLine(first.EmployeeName);

            //******************************Output*******************************
            //Bernie
            //*******************************************************************

            //查询年龄大于50岁的第一位员工的姓名,若不存在，则返回N/A
            //var firstOrDefault = (from e in employees
            //                      orderby e.Age
            //                      select e).FirstOrDefault(r => r.Age > 50);
            //Console.WriteLine(firstOrDefault == null ? "N/A" : firstOrDefault.EmployeeName);

            //******************************Output*******************************
            //N/A
            //*******************************************************************

            #endregion

            #region 聚合操作符   Count、Sum、Min、Max、Average、Aggregate
            //查找有一个以上爱好的员工的姓名、爱好的数量及部门
            //var count = from e in employees
            //            let numberHobby = e.Hobby.Count()
            //            where numberHobby > 1
            //            select new
            //            {
            //                e.EmployeeName,
            //                numberHobby,
            //                e.Department
            //            };
            //foreach (var item in count)
            //{
            //    Console.WriteLine("EmployeeName: " + item.EmployeeName + " NumberHobby: " + item.numberHobby + " Department: " + item.Department);
            //}

            //******************************Output*******************************
            //EmployeeName: Mike NumberHobby: 2 Department: IT
            //EmployeeName: Adolph NumberHobby: 3 Department: IT
            //EmployeeName: Antony NumberHobby: 2 Department: FD
            //EmployeeName: Carl NumberHobby: 2 Department: QC
            //EmployeeName: Aimee NumberHobby: 2 Department: HR
            //*******************************************************************

            //计算所有员工薪水的总和
            //var sum = (from e in employees
            //           select e.Salary).Sum/*Min、Max、Average*/();
            //Console.WriteLine(sum.ToString("N0"));

            //******************************Output*******************************
            //2,149,989
            //*******************************************************************

            //初始值为50000000，依次累加所有员工的薪水,对最终的结果乘2
            //var aggregate = (from e in employees
            //                 select e.Salary).Aggregate(5000000, (x, y) => x + y, r => r * 2);
            //Console.WriteLine(aggregate.ToString("N0"));

            //******************************Output*******************************
            //14,299,978
            //*******************************************************************
            #endregion

            #region 转换操作符   ToArray、AsEnumerable、ToList、ToDictionary、Cast<TResult>
            //将年龄大于30岁的元素放入list中再循环输出。
            //List<Employee> employeeList = (from e in employees
            //                               where e.Age > 30
            //                               select e).ToList();
            //foreach (var item in employeeList)
            //{
            //    Console.WriteLine("EmployeeName: " + item.EmployeeName + " Age:" + item.Age);
            //}

            //******************************Output*******************************
            //EmployeeName: Mike Age:32
            //EmployeeName: Jack Age:38
            //EmployeeName: Bernie Age:31
            //EmployeeName: Cassie Age:31
            //*******************************************************************

            #endregion

            #region 生成操作符   Empty、Range、Repeat
            //生成一个int类型的空序列
            //var empty = Enumerable.Empty<int>();          
            //Console.WriteLine(empty.Count());

            //******************************Output*******************************
            //0
            //*******************************************************************

            //生成一个从1开始，10个元素的序列
            //var range = Enumerable.Range(1, 10);
            //foreach (var item in range)
            //{
            //    Console.WriteLine(item);
            //}

            //******************************Output*******************************
            //1
            //2
            //3
            //4
            //5
            //6
            //7
            //8
            //9
            //10
            //*******************************************************************

            //生成一个10个元素，每个元素都是5的序列
            //var repeat = Enumerable.Repeat(5, 10);
            //foreach (var item in repeat)
            //{
            //    Console.WriteLine(item);
            //}

            //******************************Output*******************************
            //5
            //5
            //5
            //5
            //5
            //5
            //5
            //5
            //5
            //5
            //*******************************************************************
            #endregion

            Console.ReadLine();
        }




    }

    /// <summary>
    /// 员工类
    /// </summary>
    public class Employee
    {
        //员工编号
        public string EmployeeId { get; private set; }
        //员工姓名
        public string EmployeeName { get; private set; }
        //年龄
        public int Age { get; private set; }
        //入职日期
        public DateTime EntryDate { get; private set; }
        //性别
        public string Sex { get; private set; }
        //部门
        public string Department { get; private set; }
        //薪水
        public int Salary { get; private set; }
        //爱好
        public IEnumerable<string> Hobby { get; private set; }

        public Employee(string employeeId, string employeeName, int age, DateTime entryDate, Sex sex, Department department, int salary, IEnumerable<string> hobby)
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employeeName;
            this.Age = age;
            this.EntryDate = entryDate;
            this.Sex = sex.ToString();
            this.Department = department.ToString();
            this.Salary = salary;
            this.Hobby = hobby;
        }
    }

    //性别
    public enum Sex
    {
        Male,
        Female
    }

    //部门
    public enum Department
    {
        HR,
        IT,
        PD,
        FD,
        QC,
        MD
    }

    /// <summary>
    /// 部门信息
    /// </summary>
    public class DepartmentInfo
    {
        //部门编号
        public string DepartmentId { get; private set; }
        //部门名称
        public string DepartmentName { get; private set; }
        //部门总监
        public string Director { get; private set; }

        public DepartmentInfo(string departmentId, string departmentName, string director)
        {
            this.DepartmentId = departmentId;
            this.DepartmentName = departmentName;
            this.Director = director;
        }
    }

    /// <summary>
    /// 杰出团队
    /// </summary>
    public class OutstandingTeam
    {
        public int Year { get; private set; }
        public string Department { get; private set; }

        public OutstandingTeam(int year, string department)
        {
            this.Year = year;
            this.Department = department;
        }
    }

}
