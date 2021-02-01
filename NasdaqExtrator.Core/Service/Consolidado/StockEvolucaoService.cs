﻿using NasdaqExtrator.Core.Entity.Consolidado;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Service.Consolidado
{
    public class StockEvolucaoService : IStockEvolucaoService
    {
        public List<StockEvolucaoEntity> ListarMelhores(int quantidadeRegistros, int quantidadeAnos)
        {
            return new List<StockEvolucaoEntity>
            {
                new StockEvolucaoEntity("IBM", new List<StockEvolucaoAnoEntity>{
                        new StockEvolucaoAnoEntity(2021, 10m),
                        new StockEvolucaoAnoEntity(2020, 9.23m)
                    })
            };
        }
    }
}