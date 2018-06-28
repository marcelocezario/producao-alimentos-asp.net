﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class InsumosComposicaoProdutosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: InsumosComposicaoProdutos
        public ActionResult Index()
        {
            var insumosComposicaoProdutos = db.InsumosComposicaoProdutos.Include(i => i._Insumo).Include(i => i._Produto);
            return View(insumosComposicaoProdutos.ToList());
        }

        // GET: InsumosComposicaoProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsumoComposicaoProduto insumoComposicaoProduto = db.InsumosComposicaoProdutos.Find(id);
            if (insumoComposicaoProduto == null)
            {
                return HttpNotFound();
            }
            return View(insumoComposicaoProduto);
        }

        // GET: InsumosComposicaoProdutos/Create
        public ActionResult Create()
        {
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome");
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome");
            return View();
        }

        // POST: InsumosComposicaoProdutos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsumoComposicaoProdutoID,QtdeInsumo,InsumoID,ProdutoID")] InsumoComposicaoProduto insumoComposicaoProduto)
        {
            if (ModelState.IsValid)
            {
                db.InsumosComposicaoProdutos.Add(insumoComposicaoProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", insumoComposicaoProduto.InsumoID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", insumoComposicaoProduto.ProdutoID);
            return View(insumoComposicaoProduto);
        }

        // GET: InsumosComposicaoProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsumoComposicaoProduto insumoComposicaoProduto = db.InsumosComposicaoProdutos.Find(id);
            if (insumoComposicaoProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", insumoComposicaoProduto.InsumoID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", insumoComposicaoProduto.ProdutoID);
            return View(insumoComposicaoProduto);
        }

        // POST: InsumosComposicaoProdutos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsumoComposicaoProdutoID,QtdeInsumo,InsumoID,ProdutoID")] InsumoComposicaoProduto insumoComposicaoProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumoComposicaoProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", insumoComposicaoProduto.InsumoID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", insumoComposicaoProduto.ProdutoID);
            return View(insumoComposicaoProduto);
        }

        // GET: InsumosComposicaoProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsumoComposicaoProduto insumoComposicaoProduto = db.InsumosComposicaoProdutos.Find(id);
            if (insumoComposicaoProduto == null)
            {
                return HttpNotFound();
            }
            return View(insumoComposicaoProduto);
        }

        // POST: InsumosComposicaoProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsumoComposicaoProduto insumoComposicaoProduto = db.InsumosComposicaoProdutos.Find(id);
            db.InsumosComposicaoProdutos.Remove(insumoComposicaoProduto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
