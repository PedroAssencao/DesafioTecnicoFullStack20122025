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
      const errorData = await response.json();
      if (errorData.messages && Array.isArray(errorData.messages)) {
        const errorText = errorData.messages
          .map((m: any) => m.message)
          .join("\n");
        alert(`Erro de validação:\n${errorText}`);
      }
      throw errorData;
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
      const errorData = await response.json();
      if (errorData.messages && Array.isArray(errorData.messages)) {
        const errorText = errorData.messages
          .map((m: any) => m.message)
          .join("\n");
        alert(`Erro de validação:\n${errorText}`);
      }
      throw errorData;
    }

    const resultado: Pessoa = await response.json();
    alert("Pessoa cadastrada com sucesso!");
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
      const errorData = await response.json();
      if (errorData.messages && Array.isArray(errorData.messages)) {
        const errorText = errorData.messages
          .map((m: any) => m.message)
          .join("\n");
        alert(`Erro de validação:\n${errorText}`);
      }
      return false;
    }

    const sucesso: boolean = await response.json();
    alert("Pessoa atualizada com sucesso!");
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
      const errorData = await response.json();
      if (errorData.messages && Array.isArray(errorData.messages)) {
        const errorText = errorData.messages
          .map((m: any) => m.message)
          .join("\n");
        alert(`Erro de validação:\n${errorText}`);
      }
      return false;
    }

    const sucesso: boolean = await response.json();
    alert("Pessoa deletada com sucesso!");
    return sucesso;
  } catch (error) {
    console.error("Falha na comunicação ao tentar deletar:", error);
    return false;
  }
}
