export interface Finalidade {
  codigo: number;
  descricao: string;
}

export interface Categoria {
  codigo: number;
  nome: string;
  finalidade: Finalidade;
}
