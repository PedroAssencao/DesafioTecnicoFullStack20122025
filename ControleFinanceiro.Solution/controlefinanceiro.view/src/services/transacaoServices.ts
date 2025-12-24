import type {
  Transacao,
  TransacaoCriarDTO,
} from "../types/baseTypes/Transacao";
import { AlertService } from "../util/alertUtils";
import Swal from "sweetalert2";

const apiUrl = "https://localhost:8081/api/";

const handleApiError = async (response: Response) => {
  const errorData = await response.json();
  if (errorData.messages && Array.isArray(errorData.messages)) {
    const errorText = errorData.messages
      .map((m: any) => m.message)
      .join("<br>");

    Swal.fire({
      icon: "error",
      title: "Erro de validação",
      background: "#1B1E25",
      color: "#fff",
      html: errorText,
      confirmButtonColor: "#d33",
    });
  }
  return errorData;
};

export async function getTransacoes(): Promise<Transacao[]> {
  try {
    const response = await fetch(
      `${apiUrl}v1/Transacoes/BuscarTodasAsTransacoes`,
      {
        method: "GET",
        headers: {
          accept: "*/*",
        },
      }
    );

    if (!response.ok) {
      const errorData = await handleApiError(response);
      throw errorData;
    }

    return await response.json();
  } catch (error) {
    console.error(error);
    throw error;
  }
}

export async function cadastrarNovaTransacao(
  dados: TransacaoCriarDTO
): Promise<Transacao | void> {
  try {
    const response = await fetch(`${apiUrl}v1/Transacoes/CriarTransacao`, {
      method: "POST",
      headers: {
        accept: "*/*",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(dados),
    });

    if (!response.ok) {
      const errorData = await handleApiError(response);
      throw errorData;
    }

    const resultado: Transacao = await response.json();
    AlertService.success("Sucesso", "Transação realizada com sucesso!");
    return resultado;
  } catch (error) {
    console.error(error);
  }
}
