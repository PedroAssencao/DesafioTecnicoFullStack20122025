import Swal from "sweetalert2";

const Toast = Swal.mixin({
  timer: 3000,
  timerProgressBar: true,
  background: "#1B1E25",
  color: "#fff",
  confirmButtonColor: "#272A31",
  cancelButtonColor: "#d33",
});

export const AlertService = {
  success: (title: string, text?: string) => {
    return Toast.fire({
      icon: "success",
      title,
      color: "#fff",
      background: "#1B1E25",
      text,
    });
  },

  error: (title: string, text?: string) => {
    return Swal.fire({
      icon: "error",
      title,
      text,
      color: "#fff",
      background: "#1B1E25",
      confirmButtonColor: "#d33",
    });
  },

  confirmDelete: async (itemNome: string) => {
    const result = await Swal.fire({
      title: "Tem certeza?",
      text: `Você está prestes a excluir "${itemNome}". Esta ação não pode ser desfeita!`,
      icon: "warning",
      showCancelButton: true,
      color: "#fff",
      confirmButtonColor: "#d33",
      background: "#1B1E25",
      cancelButtonColor: "#272A31",
      confirmButtonText: "Sim, deletar!",
      cancelButtonText: "Cancelar",
    });

    return result.isConfirmed;
  },
};
