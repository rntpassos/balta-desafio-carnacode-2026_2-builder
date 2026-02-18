// DESAFIO: Gerador de Relatórios Complexos
// PROBLEMA: Sistema precisa gerar diferentes tipos de relatórios (PDF, Excel, HTML)
// com múltiplas configurações opcionais (cabeçalho, rodapé, gráficos, tabelas, filtros)
// O código atual usa construtores enormes ou muitos setters, tornando difícil criar relatórios

using System;
using System.Collections.Generic;

namespace DesignPatternChallenge
{
    // Contexto: Sistema de BI que gera relatórios customizados para diferentes departamentos
    // Cada relatório pode ter dezenas de configurações opcionais
    
    public class SalesReport
    {
        public string Title { get; set; }
        public string Format { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IncludeHeader { get; set; }
        public bool IncludeFooter { get; set; }
        public string HeaderText { get; set; }
        public string FooterText { get; set; }
        public bool IncludeCharts { get; set; }
        public string ChartType { get; set; }
        public bool IncludeSummary { get; set; }
        public List<string> Columns { get; set; }
        public List<string> Filters { get; set; }
        public string SortBy { get; set; }
        public string GroupBy { get; set; }
        public bool IncludeTotals { get; set; }
        public string Orientation { get; set; }
        public string PageSize { get; set; }
        public bool IncludePageNumbers { get; set; }
        public string CompanyLogo { get; set; }
        public string WaterMark { get; set; }

        public void Generate()
        {
            Console.WriteLine($"\n=== Gerando Relatório: {Title} ===");
            Console.WriteLine($"Formato: {Format}");
            Console.WriteLine($"Período: {StartDate:dd/MM/yyyy} a {EndDate:dd/MM/yyyy}");
            
            if (IncludeHeader)
                Console.WriteLine($"Cabeçalho: {HeaderText}");
            
            if (IncludeCharts)
                Console.WriteLine($"Gráfico: {ChartType}");
            
            Console.WriteLine($"Colunas: {string.Join(", ", Columns)}");
            
            if (Filters.Count > 0)
                Console.WriteLine($"Filtros: {string.Join(", ", Filters)}");
            
            if (!string.IsNullOrEmpty(GroupBy))
                Console.WriteLine($"Agrupado por: {GroupBy}");
            
            if (IncludeFooter)
                Console.WriteLine($"Rodapé: {FooterText}");
            
            Console.WriteLine("Relatório gerado com sucesso!");
        }
    }

    public interface ISalesReportBuilder
    {
        void Title(string title);
        void Format(string format);
        void StartDate(DateTime startDate);
        void EndDate(DateTime endDate);
        void IncludeHeader(bool includeHeader);
        void IncludeFooter(bool includeFooter);
        void HeaderText(string headerText);
        void FooterText(string footerText);
        void IncludeCharts(bool includeCharts);
        void ChartType(string chartType);
        void IncludeSummary(bool includeSummary);
        void Columns(List<string> columns);
        void Filters(List<string> filters);
        void SortBy(string sortBy);
        void GroupBy(string groupBy);
        void IncludeTotals(bool includeTotals);
        void Orientation(string orientation);
        void PageSize(string pageSize);
        void IncludePageNumbers(bool includePageNumbers);
        void CompanyLogo(string companyLogo);
        void WaterMark(string waterMark);
        SalesReport Build();
    }

    public class SalesReportBuilder : ISalesReportBuilder
    {
        private readonly SalesReport _report = new();
        public void Title(string title) => _report.Title = title;
        public void Format(string format) => _report.Format = format;
        public void StartDate(DateTime startDate) => _report.StartDate = startDate;
        public void EndDate(DateTime endDate) => _report.EndDate = endDate;
        public void IncludeHeader(bool includeHeader) => _report.IncludeHeader = includeHeader;
        public void IncludeFooter(bool includeFooter) => _report.IncludeFooter = includeFooter;
        public void HeaderText(string headerText) => _report.HeaderText = headerText;
        public void FooterText(string footerText) => _report.FooterText = footerText;
        public void IncludeCharts(bool includeCharts) => _report.IncludeCharts = includeCharts;
        public void ChartType(string chartType) => _report.ChartType = chartType;
        public void IncludeSummary(bool includeSummary) => _report.IncludeSummary = includeSummary;
        public void Columns(List<string> columns) => _report.Columns = columns;
        public void Filters(List<string> filters) => _report.Filters = filters;
        public void SortBy(string sortBy) => _report.SortBy = sortBy;
        public void GroupBy(string groupBy) => _report.GroupBy = groupBy;
        public void IncludeTotals(bool includeTotals) => _report.IncludeTotals = includeTotals;
        public void Orientation(string orientation) => _report.Orientation = orientation;
        public void PageSize(string pageSize) => _report.PageSize = pageSize;
        public void IncludePageNumbers(bool includePageNumbers) => _report.IncludePageNumbers = includePageNumbers;
        public void CompanyLogo(string companyLogo) => _report.CompanyLogo = companyLogo;
        public void WaterMark(string waterMark) => _report.WaterMark = waterMark;
        public SalesReport Build() => _report;
    }

    public class SalesReportDirector
    {
        public SalesReport BuildReport1(ISalesReportBuilder builder)
        {
            builder.Title("Vendas Mensais");
            builder.Format("PDF");
            builder.StartDate(new DateTime(2024, 1, 1));
            builder.EndDate(new DateTime(2024, 1, 31));
            builder.IncludeHeader(true);
            builder.IncludeFooter(true);
            builder.HeaderText("Relatório de Vendas");
            builder.FooterText("Confidencial");
            builder.IncludeCharts(true);
            builder.ChartType("Bar");
            builder.IncludeSummary(true);
            builder.Columns(new List<string> { "Produto", "Quantidade", "Valor" });
            builder.Filters(new List<string> { "Status=Ativo" });
            builder.SortBy("Valor");
            builder.GroupBy("Categoria");
            builder.IncludeTotals(true);
            builder.Orientation("Portrait");
            builder.PageSize("A4");
            builder.IncludePageNumbers(true);
            builder.CompanyLogo("logo.png");
            builder.WaterMark("Confidencial");
            return builder.Build();
        }
        public SalesReport BuildReport2(ISalesReportBuilder builder)
        {
            builder.Title("Relatório Trimestral");
            builder.Format("Excel");
            builder.StartDate(new DateTime(2024, 1, 1));
            builder.EndDate(new DateTime(2024, 3, 31));
            builder.Columns(new List<string> { "Vendedor", "Região", "Total" });
            builder.IncludeCharts(true);
            builder.ChartType("Line");
            builder.IncludeHeader(true);
            builder.GroupBy("Região");
            builder.IncludeTotals(true);
            return builder.Build();
        }
        public SalesReport BuildReport3(ISalesReportBuilder builder)
        {
            builder.Title("Vendas Anuais");
            builder.Format("PDF");
            builder.StartDate(new DateTime(2024, 1, 1));
            builder.EndDate(new DateTime(2024, 12, 31));
            builder.IncludeHeader(true);
            builder.HeaderText("Relatório de Vendas");
            builder.IncludeFooter(true);
            builder.FooterText("Confidencial");
            builder.Columns(new List<string> { "Produto", "Quantidade", "Valor" });
            builder.IncludeCharts(true);
            builder.ChartType("Pie");
            builder.IncludeTotals(true);
            builder.Orientation("Landscape");
            builder.PageSize("A4");
            return builder.Build();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Relatórios ===");

            var builder = new SalesReportBuilder();
            var director = new SalesReportDirector();
            var report1 = director.BuildReport1(builder);
            report1.Generate();
            var report2 = director.BuildReport2(builder);
            report2.Generate();
            var report3 = director.BuildReport3(builder);
            report3.Generate();

            // Respostas:
            // - Como criar relatórios complexos sem construtores gigantes?
            //   Utilizando o padrão Builder, podemos construir relatórios passo a passo, evitando construtores telescópicos e melhorando a legibilidade.
            // - Como garantir que configurações obrigatórias sejam definidas?
            //   O Director pode garantir que certos métodos do Builder sejam chamados, e o próprio Builder pode validar os campos obrigatórios antes de gerar o relatório.
            // - Como reutilizar configurações comuns entre relatórios?
            //   Podemos criar métodos/funções auxiliares para aplicar configurações padronizadas no Builder, ou criar subclasses de Builder para cenários específicos.
            // - Como tornar o processo de criação mais legível e fluente?
            //   O uso de métodos fluentes (return this no Builder) permite encadear configurações de maneira clara e expressiva.
        }
    }
}
