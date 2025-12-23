import type { Transacao } from "./Transacao";

export interface Finalidade {
  codigo: number;
  descricao: string;
}

export interface Categoria {
  codigo: number;
  nome: string;
  finalidade: Finalidade;
  transcacoes: Transacao[];
}

export interface CategoriaCriarDTO {
  nome: string;
  finalidade: number;
}
