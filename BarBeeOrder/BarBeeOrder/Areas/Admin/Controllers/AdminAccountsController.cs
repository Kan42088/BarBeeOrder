using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarBeeOrder.Models;
using PagedList.Core;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BarBeeOrder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAccountsController : Controller
    {
        private readonly BarBeeOrderContext _context;
        public INotyfService _notyfService { get; }
        public AdminAccountsController(BarBeeOrderContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminAccounts
        public async Task<IActionResult> Index(int? page,int RolesID = 0)
        {
            ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "RoleId", "Description");

            List<SelectListItem> listStatus = new List<SelectListItem>();
            listStatus.Add(new SelectListItem() {Text ="Hoạt động",Value="1"});
            listStatus.Add(new SelectListItem() { Text = "Không hoạt động", Value = "0" });
            ViewData["TrangThai"] = listStatus;

            var pageNumber = page ?? 1;
            var pageSize = 5; //Show 5 rows every time

            List<Account> lsAccounts = new List<Account>();
            if (RolesID != 0)
            {
                lsAccounts = _context.Accounts.AsNoTracking().Where(x => x.RollId == RolesID).Include(c => c.Roll).OrderByDescending(x => x.AccountId).ToList();
            }
            else
            {
                lsAccounts = _context.Accounts.AsNoTracking().Include(c => c.Roll).OrderByDescending(x => x.AccountId).ToList();
            }

            PagedList<Account> models = new PagedList<Account>(lsAccounts.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentRoleID = RolesID;
            ViewBag.CurrentPage = pageNumber;

            //var models = _context.Accounts.Include(a => a.Roll).ToPagedList(pageNumber,pageSize);
            return View(models);
        }

        // GET: Admin/AdminAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Roll)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Admin/AdminAccounts/Create
        public IActionResult Create()
        {
            ViewData["RollId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: Admin/AdminAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Email,Password,Phone,Status,Fullname,RollId,CreatedDate,LastLogin")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RollId"] = new SelectList(_context.Roles, "RoleId", "RoleId", account.RollId);
            return View(account);
        }

        // GET: Admin/AdminAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["RollId"] = new SelectList(_context.Roles, "RoleId", "RoleId", account.RollId);
            return View(account);
        }

        // POST: Admin/AdminAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,Email,Password,Phone,Status,Fullname,RollId,CreatedDate,LastLogin")] Account account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RollId"] = new SelectList(_context.Roles, "RoleId", "RoleId", account.RollId);
            return View(account);
        }

        // GET: Admin/AdminAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Roll)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/AdminAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }
    }
}
