using bookfortable.Models;
using bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

public class SignUpController : Controller
{
    private readonly FinalContext _db;

    public SignUpController(FinalContext dbContext)
    {
        _db = dbContext;
    }

    // 顯示報名列表頁面
    public IActionResult List()
    {
        List<SingUp> signUps = _db.SingUps.ToList();
        return View(signUps);
    }

    // 顯示創建報名表單頁面
    [HttpGet]
    public IActionResult Create(int id)
    {
        CEventWrap cEventWrap = new CEventWrap();
        cEventWrap.MemberId = id;
        return View(cEventWrap);
    }

    // 處理創建報名表單的邏輯
    [HttpPost]
    public IActionResult Create(CEventWrap viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _db.SingUps.Add(viewModel.SingUps);
                _db.SaveChanges();
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "報名失敗，請稍後再試。");
                return View(viewModel);
            }
        }
        return View(viewModel);
    }

    // 顯示編輯報名記錄的表單頁面
    [HttpGet]
    public IActionResult Edit(int id)
    {
        SingUp signUp = _db.SingUps.Find(id);

        if (signUp == null)
        {
            return NotFound();
        }

        List<EvenType> eventTypes = _db.EvenTypes.ToList();
        List<SelectListItem> eventTypeOptions = eventTypes
            .Select(e => new SelectListItem
            {
                Value = e.EvenTypeId.ToString(),
                Text = e.EvenTypeName
            })
            .ToList();

        SignUpViewModel viewModel = new SignUpViewModel
        {
            EventTypeOptions = eventTypeOptions,
            SingUp = signUp
        };

        return View(viewModel);
    }

    // 處理編輯報名表單的邏輯
    [HttpPost]
    public IActionResult Edit(CEventWrap viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _db.SingUps.Update(viewModel.SingUps);
                _db.SaveChanges();
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "更新報名記錄失敗，請稍後再試。");
                return View(viewModel);
            }
        }

        viewModel.EventTypeOptions = _db.EvenTypes
            .Select(e => new SelectListItem
            {
                Value = e.EvenTypeId.ToString(),
                Text = e.EvenTypeName
            })
            .ToList();

        return View(viewModel);
    }

    // 顯示刪除報名記錄的確認頁面
    public IActionResult Delete(int id)
    {
        SingUp signUp = _db.SingUps.Find(id);

        if (signUp == null)
        {
            return NotFound();
        }

        return View(signUp);
    }

    // 處理刪除報名記錄的邏輯
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        SingUp signUp = _db.SingUps.Find(id);

        if (signUp == null)
        {
            return NotFound();
        }

        _db.SingUps.Remove(signUp);
        _db.SaveChanges();

        return RedirectToAction("List");
    }

    // 處理確認報名的邏輯
    [HttpPost]
    public IActionResult SignUps([FromBody] CEventWrap confirmSignUpData)
    {
        try
        {
            // 在這裡執行確認報名的相關邏輯
            // 假設確認報名成功，返回成功的 JSON 響應
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            // 確認報名失敗，返回失敗的 JSON 響應
            return Json(new { success = false, error = ex.Message });
        }
    }

    // 處理取消報名的邏輯
    [HttpPost]
    public IActionResult CancelSignUp([FromBody] CEventWrap cancelSignUpData)
    {
        try
        {
            // 在這裡執行取消報名的相關邏輯
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
