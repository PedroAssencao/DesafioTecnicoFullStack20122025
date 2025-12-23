import { type Transacao } from "./Transacao";

export interface Pessoa {
  codigo: number;
  nome: string;
  idade: number;
  transacoes: Transacao[];
}
