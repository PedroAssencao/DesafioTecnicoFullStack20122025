import { type Categoria } from "./Categoria";

export interface TipoTransacao {
  codigo: number;
  descricao: string;
}

export interface Transacao {
  codigo: number;
  descricao: string;
  valor: number;
  tipo: TipoTransacao;
  categoria: Categoria;
}
