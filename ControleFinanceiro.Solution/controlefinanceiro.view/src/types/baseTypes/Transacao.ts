import { type Categoria } from "./Categoria";
import { type Pessoa } from "./Pessoa";

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
  pessoa: Pessoa;
}

export interface TransacaoCriarDTO {
  descricao: string;
  valor: number;
  tipo: number;
  categoriaCodigo: number;
  valorDisplay: string;
  pessoaCodigo: number;
}
