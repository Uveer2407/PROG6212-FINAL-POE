using Microsoft.AspNetCore.Mvc;
using CMCS.Models;
using System.Linq;

namespace CMCS.Controllers
{
    public class ClaimController : Controller
    {
        private readonly DatabaseContext _context;

        public ClaimController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            var userId = HttpContext.Session.GetInt32("UserId");

            if (role == "Lecturer")
            {
                var claims = _context.Claims.Where(c => c.LecturerId == userId).ToList();
                return View(claims);
            }
            else if (role == "Admin")
            {
                var claims = _context.Claims.ToList();
                return View(claims);
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Details(int id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveReject(int claimId, bool isApproved, string rejectionReason)
        {
            var claim = await _context.Claims.FindAsync(claimId);
            if (claim == null)
            {
                return NotFound();
            }

            claim.Status = isApproved ? "Approved" : "Rejected";
            claim.RejectionReason = rejectionReason; // Save the rejection reason if any
            _context.Update(claim);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
