import type {
  Pessoa,
  PessoaAtualizarDTO,
  PessoaCriarDTO,
} from "../types/baseTypes/Pessoa";

const apiUrl = "https://localhost:8081/api/";

export async function getPessoas(): Promise<Pessoa[]> {
  try {
    const response = await fetch(`${apiUrl}v1/Pessoa/BuscarTodasAsPessoas`);

    if (!response.ok) {
      throw new Error(
        `Erro na requisição: ${response.status} ${response.statusText}`
      );
    }

    const data: Pessoa[] = await response.json();
    return data;
  } catch (error) {
    console.error("Falha ao buscar pessoas:", error);
    throw error;
  }
}

export async function cadastrarNovaPessoa(
  dados: PessoaCriarDTO
): Promise<Pessoa | void> {
  try {
    const response = await fetch(apiUrl + "v1/Pessoa/CadastrarNovaPessoa", {
      method: "POST",
      headers: {
        accept: "*/*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(dados),
    });

    if (!response.ok) {
      throw new Error(`Erro na requisição: ${response.statusText}`);
    }

    const resultado: Pessoa = await response.json();
    console.log("Pessoa cadastrada com sucesso:", resultado);
    return resultado;
  } catch (error) {
    console.error("Falha ao cadastrar pessoa:", error);
  }
}

export async function atualizarPessoa(
  dados: PessoaAtualizarDTO
): Promise<boolean> {
  try {
    const response = await fetch(apiUrl + "v1/Pessoa/AtualizarPessoa", {
      method: "PUT",
      headers: {
        accept: "*/*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(dados),
    });

    if (!response.ok) {
      console.error(`Erro ao atualizar: ${response.status}`);
      return false;
    }

    const sucesso: boolean = await response.json();
    return sucesso;
  } catch (error) {
    console.error("Falha na comunicação com o servidor:", error);
    return false;
  }
}

export async function deletarPessoa(id: number): Promise<boolean> {
  try {
    const urlComParametro = `${apiUrl}v1/Pessoa/DeletarPessoa?id=${id}`;

    const response = await fetch(urlComParametro, {
      method: "DELETE",
      headers: {
        accept: "*/*",
      },
    });

    if (!response.ok) {
      console.error(`Erro ao deletar: ${response.status}`);
      return false;
    }

    const sucesso: boolean = await response.json();
    return sucesso;
  } catch (error) {
    console.error("Falha na comunicação ao tentar deletar:", error);
    return false;
  }
}
