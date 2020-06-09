using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

namespace Tests
{
    public class PartidaTest
    {
        [Test]
        public void PartidaListSeInsertan_test()
        {
            var registro = new RegistroCategoria();
            registro.InsertarCategoria("domesticos");
            registro.InsertarCategoria("sabana");
            registro.InsertarCategoria("bosque");
            IIteratorCategoria iterator = registro.ObtenerIterator();
            Assert.AreEqual(true, iterator.QuedanElementos());
        }
        [Test]
        public void PartidaListSeVacia_test()
        {
            var registro = new RegistroCategoria();
            registro.InsertarCategoria("domesticos");
            registro.InsertarCategoria("sabana");
            registro.InsertarCategoria("bosque");
            IIteratorCategoria iterator = registro.ObtenerIterator();
            while (iterator.QuedanElementos())
            {
                iterator.Siguiente();
            }
            Assert.AreEqual(false, iterator.QuedanElementos()); 
        }
        [Test]
        public void PartidaIndiceFueraDeLista_test()
        {
            var registro = new RegistroCategoria();
            IIteratorCategoria iterator = registro.ObtenerIterator();
            string a;
            Assert.That(() => a = iterator.Aleatorio(), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
