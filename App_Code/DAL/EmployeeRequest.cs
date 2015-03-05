using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeRequest
/// </summary>
public class EmployeeRequest
{
	public EmployeeRequest()
	{
        //
        EMPLOYEE_NO = "";
        EMPLOYEE_SURNAME = "";
        EMPLOYEE_OTHERNAMES = "";
        EMPLOYMENT_DATE = "";
        GRADE_LEVEL = "";
        EMAIL = "";
       
	}

    public string EMPLOYEE_NO { set; get; }
    public string EMPLOYEE_SURNAME { set; get; }
    public string EMPLOYEE_OTHERNAMES { set; get; }
    public string EMPLOYMENT_DATE { set; get; }
    public string GRADE_LEVEL { set; get; }
    public string EMAIL { set; get; }
    
}