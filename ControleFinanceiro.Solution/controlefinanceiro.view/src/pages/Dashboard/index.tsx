import Card from "../../components/Card/card";
import { getPessoas } from "../../services/pessoaServices";
import { useEffect, useState } from "react";
import { type Pessoa } from "../../types/baseTypes/Pessoa";

import "./style.css";

export default function Dashboard() {
  const [listPessoas, setListPessoas] = useState<Pessoa[]>([]);

  useEffect(() => {
    async function fetchData() {
      const pessoas = await getPessoas();
      console.log("Lista de pessoas dentro da função", pessoas);
      setListPessoas(pessoas);
    }
    fetchData();
  }, []);
  console.log(listPessoas);
  return (
    <>
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
