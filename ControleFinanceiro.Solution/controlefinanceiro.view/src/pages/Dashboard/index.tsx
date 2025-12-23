import Card from "../../components/Card/card";
import { getPessoas } from "../../services/pessoaServices";
import { getCategorias } from "../../services/categoriaServices";
import { getTransacoes } from "../../services/transacaoServices";
import { useEffect, useState } from "react";
import { type Pessoa } from "../../types/baseTypes/Pessoa";

import "./style.css";
import type { Categoria } from "../../types/baseTypes/Categoria";
import type { Transacao } from "../../types/baseTypes/Transacao";
import Loader from "../../components/Loader/Loader";

export default function Dashboard() {
  const [listPessoas, setListPessoas] = useState<Pessoa[]>([]);
  const [listCategorias, setListCategorias] = useState<Categoria[]>([]);
  const [listTransacoes, setListTransacoes] = useState<Transacao[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    async function fetchData() {
      const pessoas = await getPessoas();
      const categorias = await getCategorias();
      const transacoes = await getTransacoes();
      setListCategorias(categorias);
      setListTransacoes(transacoes);
      setListPessoas(pessoas);
      setLoading(false);
    }
    fetchData();
  }, []);
  return (
    <>
      {loading && <Loader />}
      <div className={"card-grid-dashboard"}>
        <Card
          className="card-fullScreen"
          hasHeader={true}
          title="Consulta de totais por pessoa"
          hasTable={true}
        />
        <Card
          className="card-sg"
          hasHeader={true}
          title="Consulta de totais por categoria"
        />
        <Card className="card-sg" hasHeader={true} title="Ultimas transações" />
      </div>
    </>
  );
}
