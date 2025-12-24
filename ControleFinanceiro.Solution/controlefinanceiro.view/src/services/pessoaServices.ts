import type {
  Pessoa,
  PessoaAtualizarDTO,
  PessoaCriarDTO,
} from "../types/baseTypes/Pessoa";
import { AlertService } from "../util/alertUtils";
import Swal from 'sweetalert2';

const apiUrl = "https://localhost:8081/api/";

const handleApiError = async (response: Response) => {
  const errorData = await response.json();
  if (errorData.messages && Array.isArray(errorData.messages)) {
    const errorText = errorData.messages
      .map((m: any) => m.message)
      .join("<br>");
    
    Swal.fire({
      icon: 'error',
      title: 'Erro de validação',
      html: errorText,
      background: "#1B1E25",
      color: "#fff",
      confirmButtonColor: '#d33',
    });
  }
  return errorData;
};

export async function getPessoas(): Promise<Pessoa[]> {
  try {
    const response = await fetch(`${apiUrl}v1/Pessoa/BuscarTodasAsPessoas`);

    if (!response.ok) {
      const errorData = await handleApiError(response);
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
      await handleApiError(response);
      return;
    }

    const resultado: Pessoa = await response.json();
    AlertService.success("Sucesso", "Pessoa cadastrada com sucesso!");
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
      await handleApiError(response);
      return false;
    }

    const sucesso: boolean = await response.json();
    AlertService.success("Sucesso", "Pessoa atualizada com sucesso!");
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
      await handleApiError(response);
      return false;
    }

    const sucesso: boolean = await response.json();
    AlertService.success("Sucesso", "Pessoa deletada com sucesso!");
    return sucesso;
  } catch (error) {
    console.error("Falha na comunicação ao tentar deletar:", error);
    return false;
  }
}