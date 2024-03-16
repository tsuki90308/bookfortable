using bookfortable.Models;
using System.ComponentModel.DataAnnotations;

namespace Bookfortable.Models
{
    public class CResultWrap
    {
        private Result _result;
        public Result result
        {
            get
            {
                return _result;
            }
            set { _result = value; }
        }
        public CResultWrap()
        {
            _result = new Result();
        }
        public int ResultId
        {
            get
            {
                return _result.ResultId;
            }
            set { _result.ResultId = value; }
        }
        [Display(Name = "結果名稱")]
        public string? ResultName
        {
            get
            {
                return _result.ResultName;
            }
            set { _result.ResultName = value; }
        }

        [Display(Name = "描述")]
        public string? ResultMsg
        {
            get
            {
                return _result.ResultMsg;
            }
            set { _result.ResultMsg = value; }
        }
        [Display(Name = "結果圖")]
        public string? ResultImg
        {
            get
            {
                return _result.ResultImg;
            }
            set { _result.ResultImg = value; }
        }
        [Display(Name = "書籤")]
        public string? ResultTag
        {
            get
            {
                return _result.ResultTag;
            }
            set { _result.ResultTag = value; }
        }

        public IFormFile photo { get; set; }
    }
}