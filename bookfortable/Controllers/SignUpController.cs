using bookfortable.Models;
using bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SignUpController : Controller
{
    private readonly FinalContext _db=new FinalContext();

    public SignUpController(FinalContext dbContext)
    {
        _db = dbContext;
    }

    // 显示报名列表页面
    public IActionResult List()
    {
        // 获取报名列表
        List<SingUp> signUps = _db.SingUps.ToList();

        return View(signUps);
    }

    // 显示创建报名表单页面
    //public IActionResult Create()
    //{

    //    // 获取事件类型的选项
    //    List<EvenType> eventTypes = _db.EvenTypes.ToList();

    //    // 初始化下拉式选择框的选项
    //    List<SelectListItem> eventTypeOptions = eventTypes
    //        .Select(e => new SelectListItem
    //        {
    //            Value = e.EvenTypeId.ToString(),
    //            Text = e.EvenTypeName
    //        })
    //        .ToList();



    //    var SingUpsList = _db.SingUps;
    //    var SignUpIdTypes = SingUpsList.Select(s => new { s.SignUpId, s.EventAddress }).ToList();
    //    // 初始化下拉式选择框的选项
    //    List<SelectListItem> SignUpIdTypeOptions = SignUpIdTypes
    //        .Select(e => new SelectListItem
    //        {
    //            Value = e.SignUpId.ToString(),
    //            Text = e.EventAddress
    //        })
    //        .ToList();


    //    var EventhostTypes = SingUpsList.Select(s => new { s.EventId, s.Eventhost }).ToList();
    //    // 初始化下拉式选择框的选项
    //    List<SelectListItem> EventhostTypeOptions = EventhostTypes
    //        .Select(e => new SelectListItem
    //        {
    //            Value = e.EventId.ToString(),
    //            Text = e.Eventhost
    //        })
    //        .ToList();

    //    CEventWrap viewModel = new CEventWrap();
    //    viewModel.EventTypeOptions = eventTypeOptions;
    //    //viewModel.signUpIdTypeOptions = SignUpIdTypeOptions;
    //    viewModel.EventAddressTypeOptions = SignUpIdTypeOptions;
    //    viewModel.EventhostOptions = EventhostTypeOptions;
    //    return View(viewModel);
    //}


    [HttpGet] // 使用 HTTP GET 方法來顯示創建表單頁面
    public IActionResult Create(int id)
    {
        CEventWrap cEventWrap = new CEventWrap();
        cEventWrap.MemberId = id;
        return View(cEventWrap);
    }

    [HttpPost] // 使用 HTTP POST 方法來處理表單提交
    public IActionResult Create(CEventWrap cEventWrap)
    {
        //if (ModelState.IsValid)
        //{
        //    _db.SingUps.Add(viewModel.SingUp);
        //    _db.SaveChanges();
        //    return RedirectToAction("List");
        //}
        //var eventTypes=_db.EvenTypes.ToList();
        //viewModel.EventType = _db.EvenTypes
        //    .Select(e => new SelectListItem
        //    {
        //        Value = e.EvenTypeId.ToString(),
        //        Text = e.EvenTypeName.ToString()
        //    }).ToList();
        //return View(viewModel);
        return RedirectToAction("List");
    }



    // 显示编辑报名记录的表单页面
    public IActionResult Edit(int id)
    {
        SingUp signUp = _db.SingUps.Find(id);

        if (signUp == null)
        {
            return NotFound();
        }

        // 获取事件类型的选项
        List<EvenType> eventTypes = _db.EvenTypes.ToList();

        // 初始化下拉式选择框的选项
        List<SelectListItem> eventTypeOptions = eventTypes
            .Select(e => new SelectListItem
            {
                Value = e.EvenTypeId.ToString(),
                Text = e.EvenTypeName
            })
            .ToList();

        // 创建 SignUpViewModel
        SignUpViewModel viewModel = new SignUpViewModel
        {
            EventTypeOptions = eventTypeOptions,
            SingUp = signUp
        };

        return View(viewModel);
    }

    // 处理编辑报名表单的逻辑
    [HttpPost]
    public IActionResult Edit(CEventWrap viewModel)
    {
        if (ModelState.IsValid)
        {
            // 在这里处理编辑报名数据，包括 viewModel.SignUp，viewModel.EventTypeId 等

            // 更新报名记录到数据库
            _db.SingUps.Update(viewModel.SingUps);
            _db.SaveChanges();

            // 重定向到报名列表页面
            return RedirectToAction("List");
        }

        // 如果模型验证失败，重新显示编辑页面
        viewModel.EventTypeOptions = _db.EvenTypes
            .Select(e => new SelectListItem
            {
                Value = e.EvenTypeId.ToString(),
                Text = e.EvenTypeName
            })
            .ToList();

        return View(viewModel);
    }

    // 显示删除报名记录的确认页面
    public IActionResult Delete(int id)
    {
        SingUp signUp = _db.SingUps.Find(id);

        if (signUp == null)
        {
            return NotFound();
        }

        return View(signUp);
    }

    // 处理删除报名记录的逻辑
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        SingUp signUp = _db.SingUps.Find(id);

        if (signUp == null)
        {
            return NotFound();
        }

        // 从数据库中删除报名记录
        _db.SingUps.Remove(signUp);
        _db.SaveChanges();

        // 重定向到报名列表页面
        return RedirectToAction("List");
    }


    [HttpPost]
    public IActionResult SignUps([FromBody] CEventWrap confirmSignUpData)
    {
        try
        {
            // 在這裡執行確認報名的相關邏輯
            // 可以將確認報名信息保存到數據庫，呼叫服務，或執行其他業務邏輯

            // 假設確認報名成功，返回成功的 JSON 響應
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            // 確認報名失敗，返回失敗的 JSON 響應
            return Json(new { success = false, error = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult CancelSignUp([FromBody] CEventWrap cancelSignUpData)
    {
        try
        {
            // 在這裡執行取消報名的相關邏輯
            // 可以從數據庫刪除報名信息，取消訂閱事件，或執行其他業務邏輯

            // 假設取消報名成功，返回成功的 JSON 響應
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            // 取消報名失敗，返回失敗的 JSON 響應
            return Json(new { success = false, error = ex.Message });
        }
    }
}


