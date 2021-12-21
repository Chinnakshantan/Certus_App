using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certus_App.PageObject
{
   public class CertusCalculatorPage
    {
      

        #region drop down
         
         
          public string State = "//*[@id='cphBanner_wzCalculator_ucSearch_ddlState']";
          public string County = "//*[@id='cphBanner_wzCalculator_ucSearch_ddlCounty']";
          public string TransactionType = "//*[@id='cphBanner_wzCalculator_ucDocumentList_drpTransactionType']";
          public string AddDocument = "//*[@id='cphBanner_wzCalculator_ucDocumentList_drpDocument']";
          
        #endregion

        #region text
            public string userNameText = "//*[@id='lvUser_lblUserName']/cufon/cufontext";
            public string TransactionId = "//*[@id='cphBanner_wzCalculator_ucResult_lblrecordingoffficeid']";

        #endregion

        #region text box
        public string AddLoanAmount = "//*[@id='cphBanner_wzCalculator_ucDocumentList_rptDocUser_docUserControl_0_txtorgmortgageamountdiv_0']";
        public string AddNoOfPages = "//*[@id='cphBanner_wzCalculator_ucDocumentList_rptDocUser_docUserControl_0_txtNoofpages_0']";

        #endregion

        #region button
            public string certusCalculator = "//*[@href='/CertusWebsite/CertusCalculator/Calculator.aspx']";
            public string NextLoanInfoBtn = "//*[@id='ibtnStepNextButton']";
            public string certusCalcSearchBtn = "//*[@id='cphBanner_wzCalculator_ucSearch_btnSearch']";
            public string certusCalcNextBtn = "//*[@id='cphBanner_wzCalculator_StartNavigationTemplateContainerID_ibtnStepFirstButton']";
            public string AddDoc = "//*[@id='cphBanner_wzCalculator_ucDocumentList_addDocUser']";

        #endregion
    }
}
