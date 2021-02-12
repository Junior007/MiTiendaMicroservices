using catalog.domain.model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.data.context
{
    class CatalogContextSeed
    {
        internal static void SeedData(IMongoCollection<Product> productCollection)
        {//
            bool existProduct = productCollection.Find(p => true).Any();

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguresProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguresProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Name="MIDSTATES PETROLEUM COMPANY, INC.",Category="Kneeland",Summary="enhance clicks-and-mortar methodologies",Description="envisioneer enterprise convergence",ImageFile="http=//dummyimage.com/240x193.png/dddddd/000000",Price=4.03M
                }

                ,new Product{Name="MIDSTATES PETROLEUM COMPANY, INC.",Category="Kneeland",Summary="enhance clicks-and-mortar methodologies",Description="envisioneer enterprise convergence",ImageFile="http://dummyimage.com/240x193.png/dddddd/000000",Price=4.03M}
                ,new Product{Name="Banco Bradesco Sa",Category="Dayne",Summary="synergize magnetic action-items",Description="productize collaborative systems",ImageFile="http://dummyimage.com/245x223.jpg/ff4444/ffffff",Price=4.03M}
                ,new Product{Name="Huttig Building Products, Inc.",Category="Connop",Summary="mesh real-time eyeballs",Description="leverage web-enabled portals",ImageFile="http://dummyimage.com/144x120.bmp/ff4444/ffffff",Price=4.03M}
                ,new Product{Name="Northern Trust Corporation",Category="Guittet",Summary="target end-to-end systems",Description="scale robust eyeballs",ImageFile="http://dummyimage.com/115x227.bmp/dddddd/000000",Price=4.03M}
                ,new Product{Name="First Trust High Income ETF",Category="Christy",Summary="harness scalable e-markets",Description="grow proactive systems",ImageFile="http://dummyimage.com/108x141.bmp/5fa2dd/ffffff",Price=4.03M}
                ,new Product{Name="Putnam High Income Bond Fund",Category="Kelloch",Summary="strategize 24/365 architectures",Description="unleash magnetic architectures",ImageFile="http://dummyimage.com/156x196.jpg/ff4444/ffffff",Price=4.03M}
                ,new Product{Name="Gevo, Inc.",Category="Room",Summary="facilitate collaborative schemas",Description="facilitate mission-critical convergence",ImageFile="http://dummyimage.com/176x208.bmp/ff4444/ffffff",Price=4.03M}
                ,new Product{Name="Bio-Rad Laboratories, Inc.",Category="Braven",Summary="repurpose sticky e-tailers",Description="monetize granular networks",ImageFile="http://dummyimage.com/145x166.png/5fa2dd/ffffff",Price=4.03M}
                ,new Product{Name="Pimco Corporate & Income Opportunity Fund",Category="Matsell",Summary="benchmark 24/7 e-tailers",Description="scale 24/7 mindshare",ImageFile="http://dummyimage.com/118x163.png/dddddd/000000",Price=4.03M}
                ,new Product{Name="Cosan Limited",Category="Corringham",Summary="deploy visionary technologies",Description="extend holistic initiatives",ImageFile="http://dummyimage.com/166x144.jpg/dddddd/000000",Price=4.03M}
                ,new Product{Name="Unum Group",Category="Saberton",Summary="productize transparent interfaces",Description="transition bleeding-edge technologies",ImageFile="http://dummyimage.com/184x170.png/5fa2dd/ffffff",Price=4.03M}
                ,new Product{Name="Selective Insurance Group, Inc.",Category="Pulbrook",Summary="synergize open-source experiences",Description="evolve viral platforms",ImageFile="http://dummyimage.com/219x231.jpg/5fa2dd/ffffff",Price=4.03M}
                ,new Product{Name="Sequential Brands Group, Inc.",Category="Brewett",Summary="implement customized metrics",Description="matrix bleeding-edge mindshare",ImageFile="http://dummyimage.com/122x130.jpg/ff4444/ffffff",Price=4.03M}
                ,new Product{Name="Arlington Asset Investment Corp",Category="Simkins",Summary="scale scalable initiatives",Description="aggregate seamless web services",ImageFile="http://dummyimage.com/160x234.png/cc0000/ffffff",Price=4.03M}
                ,new Product{Name="VictoryShares US 500 Volatility Wtd ETF",Category="Couve",Summary="engage next-generation supply-chains",Description="transition interactive supply-chains",ImageFile="http://dummyimage.com/157x121.jpg/5fa2dd/ffffff",Price=4.03M}
                ,new Product{Name="Boston Scientific Corporation",Category="Hanalan",Summary="matrix web-enabled interfaces",Description="transition scalable vortals",ImageFile="http://dummyimage.com/187x115.png/ff4444/ffffff",Price=4.03M}
                ,new Product{Name="Chatham Lodging Trust (REIT)",Category="Hexum",Summary="productize holistic relationships",Description="exploit bricks-and-clicks portals",ImageFile="http://dummyimage.com/210x132.png/dddddd/000000",Price=4.03M}
                ,new Product{Name="Alibaba Group Holding Limited",Category="Howerd",Summary="iterate distributed convergence",Description="maximize visionary eyeballs",ImageFile="http://dummyimage.com/229x101.bmp/dddddd/000000",Price=4.03M}
                ,new Product{Name="Och-Ziff Capital Management Group LLC",Category="Smiley",Summary="unleash scalable models",Description="visualize real-time deliverables",ImageFile="http://dummyimage.com/162x238.png/cc0000/ffffff",Price=4.03M}
                ,new Product{Name="Timken Steel Corporation",Category="Bold",Summary="evolve 24/365 e-services",Description="architect transparent e-business",ImageFile="http://dummyimage.com/240x150.jpg/5fa2dd/ffffff",Price=4.03M}
                ,new Product{Name="First Horizon National Corporation",Category="Clayborn",Summary="brand enterprise interfaces",Description="enable sticky action-items",ImageFile="http://dummyimage.com/192x115.jpg/cc0000/ffffff",Price=4.03M}
                ,new Product{Name="United Technologies Corporation",Category="Rishbrook",Summary="target interactive networks",Description="reintermediate interactive action-items",ImageFile="http://dummyimage.com/145x201.jpg/ff4444/ffffff",Price=4.03M}
                ,new Product{Name="Layne Christensen Company",Category="Douberday",Summary="maximize dynamic platforms",Description="benchmark best-of-breed interfaces",ImageFile="http://dummyimage.com/127x118.png/ff4444/ffffff",Price=4.03M}
                ,new Product{Name="CorVel Corp.",Category="Parriss",Summary="deliver impactful platforms",Description="generate user-centric convergence",ImageFile="http://dummyimage.com/148x153.png/5fa2dd/ffffff",Price=4.03M}

            };

        }
    }
}
