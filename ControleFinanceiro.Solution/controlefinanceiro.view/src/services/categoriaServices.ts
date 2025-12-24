import type {
  Categoria,
  CategoriaCriarDTO,
} from "../types/baseTypes/Categoria";

const apiUrl = "https://localhost:8081/api/";

export async function getCategorias(): Promise<Categoria[]> {
  try {
    const response = await fetch(
      `${apiUrl}v1/Categoria/BuscarTodasAsCategorias`,
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

export async function cadastrarNovaCategoria(
  dados: CategoriaCriarDTO
): Promise<Categoria | void> {
  try {
    const response = await fetch(`${apiUrl}v1/Categoria/CriarCategoria`, {
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

    const resultado: Categoria = await response.json();
    return resultado;
  } catch (error) {
    console.error(error);
  }
}
