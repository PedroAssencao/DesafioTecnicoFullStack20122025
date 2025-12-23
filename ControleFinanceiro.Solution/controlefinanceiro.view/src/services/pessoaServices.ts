import type { Pessoa } from "../types/baseTypes/Pessoa";

export async function getPessoas(): Promise<Pessoa[]> {
  const apiUrl = "https://localhost:8081/api/";
  console.log("Api url aqui", apiUrl);
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
