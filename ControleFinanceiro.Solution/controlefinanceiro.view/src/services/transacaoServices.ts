import type {
  Transacao,
  TransacaoCriarDTO,
} from "../types/baseTypes/Transacao";

const apiUrl = "https://localhost:8081/api/";

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
      throw new Error(`Erro: ${response.status}`);
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
      throw new Error(`Erro: ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.error(error);
  }
}
