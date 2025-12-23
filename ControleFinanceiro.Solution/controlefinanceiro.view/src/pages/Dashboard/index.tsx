import Card from "../../components/Card/card";
import { getPessoas, deletarPessoa } from "../../services/pessoaServices";
import {
  calcularSaldo,
  calcularTotalReceitas,
  calcularTotalDespesas,
} from "../../util/financeUtils";
import { getCategorias } from "../../services/categoriaServices";
import { getTransacoes } from "../../services/transacaoServices";
import { useEffect, useState } from "react";
import { type Pessoa } from "../../types/baseTypes/Pessoa";

import "./style.css";
import type { Categoria } from "../../types/baseTypes/Categoria";
import type { Transacao } from "../../types/baseTypes/Transacao";
import Loader from "../../components/Loader/Loader";
import type { tbodyItem } from "../../types/systemTypes/TableInterface";

export default function Dashboard() {
  const [listPessoas, setListPessoas] = useState<Pessoa[]>([]);
  const [listCategorias, setListCategorias] = useState<Categoria[]>([]);
  const [listTransacoes, setListTransacoes] = useState<Transacao[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  async function fetchData() {
    setLoading(true);
    const pessoas = await getPessoas();
    const categorias = await getCategorias();
    const transacoes = await getTransacoes();
    setListCategorias(categorias);
    setListTransacoes(transacoes);
    setListPessoas(pessoas);
    setLoading(false);
  }

  useEffect(() => {
    fetchData();
  }, []);
  console.log(listPessoas);
  return (
    <>
      {loading && <Loader />}

      <div className={"card-grid-dashboard"}>
        <Card
          className="card-sg"
          hasHeader={true}
          title="Consulta de totais por pessoa"
          hasTable={true}
          tableHead={[
            "Codigo",
            "Nome",
            "Idade",
            "Receita",
            "Despesas",
            "Saldo",
            "Deletar",
          ]}
          tableBodyItems={listPessoas.map(
            (pessoa) =>
              ({
                items: [
                  pessoa.codigo.toString(),
                  pessoa.nome,
                  pessoa.idade.toString(),
                  "R$: " + calcularTotalReceitas(pessoa.transacoes).toFixed(2),
                  "R$: " + calcularTotalDespesas(pessoa.transacoes).toFixed(2),
                  "R$: " + calcularSaldo(pessoa.transacoes).toFixed(2),
                ],
                deleteFunction: async (id: string) => {
                  const confirm = window.confirm(
                    "Tem certeza que deseja deletar esta pessoa?"
                  );
                  if (!confirm) return;
                  await deletarPessoa(parseInt(id));
                  fetchData();
                },
              } as tbodyItem)
          )}
        />
        <Card
          className="card-sg"
          hasHeader={true}
          title="Consulta de totais por categoria"
          hasTable={true}
          tableHead={[
            "Codigo",
            "Nome",
            "Finalidade",
            "Receita",
            "Despesas",
            "Saldo",
          ]}
          tableBodyItems={listCategorias.map(
            (categoria) =>
              ({
                items: [
                  categoria.codigo.toString(),
                  categoria.nome,
                  categoria.finalidade.descricao,
                  "R$: " +
                    calcularTotalReceitas(categoria.transcacoes).toFixed(2),
                  "R$: " +
                    calcularTotalDespesas(categoria.transcacoes).toFixed(2),
                  "R$: " + calcularSaldo(categoria.transcacoes).toFixed(2),
                ],
              } as tbodyItem)
          )}
        />
        <Card
          className="card-sg"
          hasHeader={true}
          title="Ultimas transações"
          hasTable={true}
          tableHead={[
            "Codigo",
            "Descrição",
            "Valor",
            "Tipo",
            "Categoria",
            "Pessoa",
          ]}
          tableBodyItems={listTransacoes
            .sort((a, b) => b.codigo - a.codigo)
            .map(
              (transacao) =>
                ({
                  items: [
                    transacao.codigo.toString(),
                    transacao.descricao,
                    "R$: " + transacao.valor.toFixed(2),
                    transacao.tipo.descricao,
                    transacao.categoria.nome,
                    transacao.pessoa.nome,
                  ],
                } as tbodyItem)
            )}
        />
      </div>
    </>
  );
}
