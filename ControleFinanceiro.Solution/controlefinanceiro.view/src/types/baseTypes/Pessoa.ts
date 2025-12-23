import { type Transacao } from "./Transacao";

export interface Pessoa {
  codigo: number;
  nome: string;
  idade: number;
  transacoes: Transacao[];
}

export interface PessoaCriarDTO {
  nome: string;
  idade: number;
}

export interface PessoaAtualizarDTO {
  codigo: number;
  nome: string;
  idade: number;
}
