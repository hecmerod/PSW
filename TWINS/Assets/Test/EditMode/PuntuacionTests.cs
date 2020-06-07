using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PuntuacionTests
    {
        [Test]
        public void PuntuacionFacil_test()
        {
            var puntuacionFacil = new PuntuacionFacil();
            var aciertos = 6;
            var fallos = 4;
            var puntuacionEsperada = 6 * 10 - (4 - 4) * 2;

            var puntos = puntuacionFacil.PuntosFinales(aciertos, fallos);

            Assert.That(puntos, Is.EqualTo(puntuacionEsperada));
        }
        [Test]
        public void PuntuacionNormal_test()
        {
            var puntuacionNormal = new PuntuacionNormal();
            var aciertos = 10;
            var fallos = 6;
            var puntuacionEsperada = 10 * 10 - (6 - 5) * 2;

            var puntos = puntuacionNormal.PuntosFinales(aciertos, fallos);

            Assert.That(puntos, Is.EqualTo(puntuacionEsperada));
        }            
        [Test]
        public void PuntuacionDificil_test()
        {
            var puntuacionDificil = new PuntuacionDificil();
            var aciertos = 16;
            var fallos = 7;
            var puntuacionEsperada = 16 * 10 - (7 - 7) * 2;

            var puntos = puntuacionDificil.PuntosFinales(aciertos, fallos);

            Assert.That(puntos, Is.EqualTo(puntuacionEsperada));
        }
        [Test]
        public void PuntuacionNoNegativa_test()
        {
            var puntuacionFacil = new PuntuacionFacil();
            var puntuacionNormal = new PuntuacionNormal();
            var puntuacionDificil = new PuntuacionDificil();
            var puntuacionEsperada = 0;

            var puntosFacil = puntuacionFacil.PuntosFinales(1, 15);
            var puntosNormal = puntuacionNormal.PuntosFinales(1, 15);
            var puntosDificil = puntuacionDificil.PuntosFinales(1, 15);

            Assert.That(puntosFacil, Is.EqualTo(puntuacionEsperada));
            Assert.That(puntosNormal, Is.EqualTo(puntuacionEsperada));
            Assert.That(puntosDificil, Is.EqualTo(puntuacionEsperada));
        }
    }
}
