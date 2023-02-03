using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace planoContas.Migrations
{
    /// <inheritdoc />
    public partial class InsertValoresIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into Contas values('1', null, 'Receitas', 1, 0);");
            migrationBuilder.Sql(@"insert into Contas values('1.1', '1','Taxa condominial',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.2', '1','Reserva de dependência',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.3', '1','Multas',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.4', '1','Juros',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.5', '1','Multa condominial',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.6', '1','Água',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.7', '1','Gás',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.8', '1','Luz e energia',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.9', '1','Fundo de reserva',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.10', '1','Fundo de obras',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.11', '1','Correção monetária',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.12', '1','Transferência entre contas',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.13', '1','Pagamento duplicado',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.14', '1','Cobrança',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.15', '1','Crédito',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.16', '1','Água mineral',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.17', '1','Estorno taxa de resgate',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.18', '1','Acordo',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('1.19', '1','Honorários',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('2', null, 'Despesas',2,0);");
            migrationBuilder.Sql(@"insert into Contas values('2.1', '2','Com pessoal',2,0);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.1', '2.1','Salário',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.2', '2.1','Adiantamento salarial',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.3', '2.1','Hora extra',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.4', '2.1','Férias',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.5', '2.1','13º salário',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.6', '2.1','Adiantamento 13º salário',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.7', '2.1','Adicional de função',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.8', '2.1','Aviso prévio',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.9', '2.1','INSS',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.10', '2.1','FGTS',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.11', '2.1','PIS',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.12', '2.1','Vale refeição',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.13', '2.1','Vale transporte',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.14', '2.1','Cesta básica',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.1.15', '2.1','Acordo trabalhista',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.2', '2','Mensais',2,0);");
            migrationBuilder.Sql(@"insert into Contas values('2.2.1', '2.2','Energia elétrica',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.2.2', '2.2','Água e esgoto',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.2.3', '2.2','Taxa de administração',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.2.4', '2.2','Gás',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.2.5', '2.2','Seguro obrigatório',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.2.6', '2.2','Telefone',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.2.7', '2.2','Softwares e aplicativos',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.3', '2','Manutenção',2,0);");
            migrationBuilder.Sql(@"insert into Contas values('2.3.1', '2.3','Elevador',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.3.2', '2.3','Limpeza e conservação',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.3.3', '2.3','Jardinagem',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.4', '2','Diversas',2,0);");
            migrationBuilder.Sql(@"insert into Contas values('2.4.1', '2.4','Honorários de advogado',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.4.2', '2.4','Xerox',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.4.3', '2.4','Correios',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.4.4', '2.4','Despesas judiciais',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.4.5', '2.4','Multas',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.4.6', '2.4','Juros',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('2.4.7', '2.4','Transferência entre contas',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('3', null, 'Despesas bancárias',2,0);");
            migrationBuilder.Sql(@"insert into Contas values('3.1', '3','Registro de boletos',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('3.2', '3','Processamento de boletos',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('3.3', '3','Registro e processamento de boletos',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('3.4', '3','Resgates',2,1);");
            migrationBuilder.Sql(@"insert into Contas values('4', null,'Outras receitas',1,0);");
            migrationBuilder.Sql(@"insert into Contas values('4.1', '4','Rendimento de poupança',1,1);");
            migrationBuilder.Sql(@"insert into Contas values('4.2', '4','Rendimento de investimentos',1,1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"delete from Contas;");
        }
    }
}
