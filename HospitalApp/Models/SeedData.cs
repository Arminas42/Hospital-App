﻿using Bogus;
using HospitalApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DBContext>>()))
            {
                if (context.Drugs.Any())
                {
                    return;   // DB has been seeded
                }
                var DrugNames = "Iclusig#Aczone#Pancreaze#Pennsaid#Aldactone#Increlex#Creon#Basaglar#Procardia#Depocyt#Cancidas#Orkambi#Samsca#Bebulin#Tradjenta#Fusilev#Tikosyn#Analpram#Inspra#Genvoya#Uribel#Treanda#Xiidra#Janumet#Marqibo#Inflectra#Activase#Erivedge#Xarelto#Soriatane#Breo#Trelegy#Kalydeco#Yaz#Alphanate#Aerochamber#Intelence#Odefsey#Plegridy#Rozerem#Fareston#Temodar#Menest#Nardil#Kristalose#Zostavax#Metabolic#Gliadel#Xeomin#Carbatrol#Primaxin#Diclegis#Elidel#Adagen#Aptivus#Sculptra#Detrol#CIMZIA#Iluvien#Impact#PurAmino#Crixivan#Imfinzi#Zinecard#Sutent#Gralise#Aranesp#Jentadueto#Feldene#Egrifta#Tybost#Orthovisc#Votrient#Bosulif#Sucraid#PCE#Pataday#Requip#Novoeight#Cytomel#Belviq#Dysport#Cetrotide#Sonata#Lunesta#Abelcet#Embeda#BeneFIX#Monurol#Alimta#EryPed#Geodon#Humalog#Elaprase#Imovax#Keytruda#HUMIRA#Erwinaze#Trokendi#Tasmar#Repatha#Forteo#Hyalgan#Recombivax#Kemadrin#Clolar#Gammagard#Auvi-Q#Colcrys#Verzenio#Auryxia#Tilade#Alfamino#Carnitor#Panhematin#LAMICTAL#Tarceva#Jardiance#Horizant#Fanapt#Dilantin#Imogam#Simponi#Maxalt-MLT#Glyset#Sabril#Krystexxa#Targretin#Droxia#Retisert#Noxafil#Cathflo#Brovana#Diabetisource#Rytary#Lonsurf#AlphaNine#Pamelor#Farydak#Xolair#Simbrinza#Liletta#Myrbetriq#Atrovent#Cuvitru#Vivitrol#Hemabate#Hysingla#Xopenex#Alvesco#Otiprio#Xifaxan#Tessalon#Brineura#Viokace#Halaven#Gamunex-C#Celebrex#Pegasys#Prevnar#NovoSeven#Soliris#Mastisol#LMX#Kogenate#Gazyva#Donnatal#Taclonex#Evotaz#Forfivo#Besponsa#Stromectol#Cosopt#Cyclogyl#Ziagen#Ofev#Arzerra#Glassia#Iressa#Lynparza#Tirosint#BiDil#Adlyxin#Elmiron#Northera#Vitekta#Emverm#Yasmin#Afstyla#Zykadia#Depakote#Estring#Betaseron#Nexavar#Synarel#Cayston#Trintellix#Thiola#Norditropin#Oxsoralen-Ultra#Apidra#Glatopa#Apriso#R-Gene#Pylera#Adynovate#Azor#Ridaura#Heparin#Zurampic#Silsoft#Aloxi#Topamax#Menopur#Ilaris#Zirgan#Duzallo#Cardura#TNKase#Epivir#Edarbi#Durezol#Hemofil#Zyclara#TOBI#SymlinPen#Zarontin#Zepatier#Evzio#Signifor#Angiomax#Copegus#Actimmune#Uceris#Maxidex#Somavert#Incruse#EMSAM#Alrex#Ravicti#Enemeez#Belsomra#Xenazine#Depo-Testosterone#Zenpep#Gilotrif#Proventil#Zioptan#Prolensa#Norvir#Skelaxin#Azulfidine#Trizivir#Kanuma#Lopid#Stimate#Varubi#MatriStem#Rexulti#Tracleer#RiaSTAP#Xyrem#Colazal#Lartruvo#NovoLog#Provenge#Mekinist#Glytrol#Austedo#Rabavert#Kyprolis#Tretten#Flagyl#Beconase#Victoza#Hepsera#Veletri#Synvisc#Trecator#Fasenra#Tolerex#Welchol#Restoril#Ellence#Provera#Tykerb#Ventolin#Flexeril#Nuedexta#Lotrisone#Cipro#Nitrostat#Timoptic#Pertzye#Zortress#Otrexup#Lumizyme#Toviaz#Depo-subQ#Florinef#Tobradex#Adempas#Eligard#Rebif#Camptosar#Defitelio#Vidaza#Trelstar#Yervoy#Focalin#Melpaque#Ovidrel#Retin-A#Amitiza#Skyla#Nevanac#Trulicity#GlucaGen#AmBisome#Sublocade#Bethkis#Glynase#Combivir#Triumeq#Renova#Kevzara#Proair#Vimpat#Namzaric#Tranxene#Medrol#Lamictal#Alomide#Procanbid#Gardasil#Prezcobix#Emflaza#Lexiva#Haldol#Dexilant#Kazano#Vaqta#Dalvance#Exjade#Praluent#Reyataz#Premphase#Tobi#Cymbalta#Bydureon#Gattex#Peptamen#Viekira#Jalyn#Angeliq#Helixate#Ixempra#Kepivance#Abraxane#Rythmol#Cyklokapron#Aubagio#Crinone#Invanz#Astagraf#Spiriva#Uloric#Invokamet#Atralin#Empliciti#Korlym#Orfadin#InnoPran#Benlysta#Tivicay#QNASL#Proglycem#Multaq#Jevtana#ORAP#Saizen#Prolia#Klor-Con#Nulojix#Cetacaine#Zolinza#Neulasta#Complera#Eloctate#Xermelo#Xalkori#Latuda#H.P.#Lialda#Mustargen#Jakafi#Aptiom#Serostim#Savaysa#Enbrel#Corgard#Cortef#Ninlaro#MuGard#Nucala#Jetrea#AndroGel#Caverject#Mirvaso#Xanax#TussiCaps#Opdivo#Tagrisso#Etopophos#Erleada#Hypercare#Fycompa#Botox#Tecfidera#Lantus#Xiaflex#Glucagon#Havrix#Levoxyl#Combigan#Lodosyn#Zelboraf#Imitrex#Prempro#Stiolto#Bacitracin#Syprine#Avastin#Banzel#Advair#Nitro-dur#Parsabiv#Emcyt#EMEND#Adcetris#Carimune#Alprolix#Ilevro#Ranexa#Fabrazyme#Neoral#Zinplava#Gonal-f#Desoxyn#Eliquis#Alinia#Mycobutin#Epiduo#Eylea#HyQvia#Matulane#Hycamtin#Rapaflo#Humulin#Stribild#Rectiv#Vibativ#Zomacton#Anusol-HC#Darzalex#Cycloset#Prenate#Harvoni#Norpace#Pulmicort#Daraprim#Granix#Natpara#Viroptic#Livalo#Effient#Alphagan#Perforomist#PuraPly#Injectafer#Menomune#Cosmegen#Zydelig#Chemet#Pristiq#Edarbyclor#Oseni#Zemaira#Nesina#Brilinta#Cystadane#Xeljanz#Albenza#Lucentis#Invega#Prolastin#Sylvant#Suboxone#Ciprodex#Genotropin#Agrylin#Monoclate-P#Saphris#Zmax#Savella#Vascepa#Venofer#Epogen#Detachol#Lupron#Diflucan#Humate-P#PERJETA#Lysodren#Alphaquin#Betimol#Cresemba#Neurontin#Gleevec#Vistide#Kalbitor#Qvar#Cerezyme#Enfamil#Nplate#Adacel#Kaletra#Azopt#Idhifa#Zavesca#Xigduo#Tanzeum#Synjardy#Viibryd#Varivax#Tygacil#Retrovir#Relpax#Monovisc#Allegra#Subsys#Accuretic#Tymlos#Procysbi#Rydapt#InFed#Mirena#VPRIV#Zithromax#Daliresp#Marplan#Erbitux#Calan#Zelapar#Fosrenol#Lincocin#Dermagraft#Promacta#Beyaz#Baraclude#Namenda#Restasis#Quillivant#Altace#Demser#Macugen#Android#Compleat#Boost#Cinqair#Fentora#Opsumit#Avonex#Onexton#Strattera#Actemra#Reclast#Advate#Apligraf#Synthroid#Lazanda#Symbicort#Orencia#NeoProfen#Leukine#Xtandi#Atripla#Toujeo#Mydayis#Adcirca#Equetro#Zejula#Besivance#Kisqali#Benicar#Concerta#Cerdelga#Lotronex#Caduet#ProAir#Aldurazyme#Cabometyx#Lupaneta#Daypro#Sovaldi#Rescriptor#Vytorin#Frova#Tecentriq#Edurant#Jublia#Technivie#Supprelin#Mytesi#Halcion#Epclusa#Glucotrol#Letairis#Portrazza#Arimidex#Aromasin#CellCept#Arnuity#Entereg#Carac#Elocon#Jadenu#Nutropin#Ancobon#Zetia#Tenivac#Byetta#Synribo#Levemir#Arranon#Viramune#Travatan#Lovenox#MoviPrep#Anoro#Zerbaxa#Velphoro#Neupogen#Buphenyl#FreeStyle#Sancuso#Emadine#Copaxone#Soliqua#Climara#Kuvan#Qutenza#Phoslyra#Blincyto#Onivyde#Thyrogen#Menactra#Dermazene#Brisdelle#Coartem#Procrit#Gabitril#Neupro#Varizig#Delzicol#Mepron#Nuvigil#Synvisc-One#Vemlidy#Betoptic#E.E.S.#Corlanor#Zevalin#Zaltrap#Cleocin#Prozac#Xyntha#Avandia#Epinephrine#Avycaz#Gengraf#Teflaro#Briviact#Cyramza#Myfortic#Kadcyla#Mycamine#Lotemax#Acanya#Akynzeo#Somatuline#Entresto#Nasonex#Lexiscan#Omnaris#Canasa#Tribenzor#Rhophylac#Zometa#Galzin#Prograf#Aristada#Vraylar#Lipitor#Systane#Lumigan#Flector#Bendeka#Engerix-B#Januvia#Tysabri#Renflexis#Alecensa#Envarsus#Ventavis#Cotellic#Urocit-K#Zoloft#Selzentry#Miacalcin#Tafinlar#Cytra-K#Kyleena#Isentress#Arestin#Biltricide#Tofranil#Tasigna#MonoNine#Singulair#Duexis#Aralast#Epivir-HBV#Pentasa#Rituxan#Emtriva#Abilify#Valcyte#Glyxambi#Trisenox#Descovy#Pregestimil#Luzu#Linzess#Corifact#Farxiga#Ingrezza#Zylet#Prodigy#Omnitrope#Xalatan#Picato#Cialis#Chantix#Celontin#Zytiga#Gilenya#Vectibix#Caprelsa#Orenitram#Oxtellar#Vyzulta#Myozyme#Desonate#Symmetrel#Trileptal#Privigen#Feiba#Peganone#Tazorac#Natazia#Proctocort#Visudyne#Remodulin#Priftin#Lemtrada#Ortho-Prefest#Gelnique#Firazyr#Aygestin#Bevespi#Vyvanse#Folotyn#Ultresa#Nutren#Revatio#XGEVA#Fetzima#Photofrin#Cinryze#Remicade#Prezista#Cuprimine#Combivent#Solodyn#Lorabid#Doxil#Lomotil#Armour#Lenvima#Taltz#Serevent#Lyrica#V-Go#Levoleucovorin#Vosevi#Berinert#HepaGam#Safyral#Nicotrol#Vfend#Venclexta#Pred#Protonix#Ocrevus#Oracea#Butrans#EpiPen#Vimovo#Optune#Soolantra#Thalitone#Viagra#Kineret#Cystaran#Symbyax#Esbriet#Sandostatin#Effexor#Depo-Medrol#Wilate#Eraxis#Vistaril#Idamycin#Movantik#Pfizerpen#Quillichew#Relenza#Pulmozyme#Renvela#Velcade#Famvir#Oxycontin#Duavee#Bystolic#Exalgo#Acuvail#Sprycel#Aldactazide#Novarel#Depo#Coreg#Flovent#Carbaglu#Cytotec#Sporanox#Felbatol#Lithostat#Lacrisert#Atgam#Myobloc#Vivonex#Maxalt#Potaba#Roxicodone#Afinitor#Yondelis#Zomig#Striverdi#Estrace#Sustiva#Noritate#Menostar#Hizentra#Marinol#Imlygic#Imbruvica#Premarin#Corvert#Tremfya#Faslodex#Amicar#Prialt#Pradaxa#Beleodaq#Flarex#Norvasc#Asmanex#Accupril#Flebogamma#Orbactiv#Viberzi#Idelvion#Anafranil#Makena#Daklinza#Pneumovax#Nutramigen#Viracept#Cosentyx#Pomalyst#Quibron#Treximet#Finacea#Kombiglyze#Zubsolv#Zarxio#Intuniv#Sotylize#Clozapine#Locoid#Rapamune#Hectorol#Ibrance#Revlimid#Vigamox#Campath#Entyvio#Rayos#Tyvaso#Invokana#Corzide#Hymovis#Relistor#Bepreve#Onglyza#Neocate#Arthrotec#Stelara#Cubicin#Elitek#Fragmin#Recombinate#WINRHO#Trusopt#Novolin#Zetonna#Inlyta#Afrezza#Extavia#Calquence#Strensiq#Nascobal#Mephyton#Evista#Primlev#Prevacid#Cholbam#Xofigo#Kovaltry#Viread#Lioresal#Phospholine#Stivarga#Colestid#Boostrix#Rayaldee#Dymista#Tegretol#Dulera#Tudorza#VESIcare#Rubraca#Thalomid#Herceptin#Triesence#Risperdal#Pazeo#Otezla#Epzicom#Ozurdex#Malarone#Sensipar#Zyprexa#Torisel#Synagis#Onfi#Sandimmune#Estrogel#Truvada#M-M-R#Mozobil#Clindagel#Rixubis#Istodax#Duac#Veltassa#Zyvox";
                string[] DrugNameArr = DrugNames.Split('#');
                var lorem = new Bogus.DataSets.Lorem("en");
                var faker = new Faker("en");
                for (int i = 0; i <= 20000; i++)
                {
                    context.Add(new Drug
                    {
                        Name = DrugNameArr[faker.Random.Number(0, 985)] + lorem.Word()

                    });
                    context.SaveChanges();
                }
               
            }
        }
    }
}
