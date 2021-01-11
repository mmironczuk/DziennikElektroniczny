﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages.Login
{
    public class UserLoginModel : PageModel
    {
        [BindProperty]
        public string login { get; set; }
        [BindProperty]
        public string password { get; set; }
        public MainDatabase mainDatabase = new MainDatabase();
        public void OnGet()
        {
        }
        public int ValidateUser(string log, string pswd)
        {
            int type = -1;
            ObservableCollection<Konto> konta = new ObservableCollection<Konto>();
            konta=mainDatabase.GetKontaAll();
            var passwordHasher = new PasswordHasher<string>();
            foreach (Konto k in konta)
            {
                if (log == k.login)
                {
                    string haslo = passwordHasher.HashPassword(login,pswd);
                    if(passwordHasher.VerifyHashedPassword(null, haslo, pswd) == PasswordVerificationResult.Success) type = k.typ_uzytkownika;
                }
            }
            return type;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            int type = -1;
            int id = 0;
            type = ValidateUser(login, password);
            Konto konto = mainDatabase.GetKontoLogin(login);
            if (type == 1) id = mainDatabase.GetNauczycielKonto(konto.Id_konta).Id_nauczyciela;
            if (type == 2) id = mainDatabase.GetUczenKonto(konto.Id_konta).Id_ucznia;
            if (type!=-1)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, login),
                    new Claim(ClaimTypes.NameIdentifier,id.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity));
                if (type == 1) return RedirectToPage("/MainNauczyciel");
                if (type == 2) return RedirectToPage("/MainUczen");
                if (type == 0) return RedirectToPage("/AdminPage");
            }
            return Page();
        }
    }
}