import { useState } from "react";
import { cadastrarNovaCategoria } from "../../../services/categoriaServices";
import Button from "../../Button/Button";
import Input from "../../Input/Input";
import Select from "../../Select/Select";
import "./style.css";

export default function CategoriaForm(props: { onSuccess: () => void }) {
  const [formData, setFormData] = useState({
    nome: "",
    finalidade: 0,
  });
  const [isSubmitting, setIsSubmitting] = useState(false);

  const finalidadeOptions = [
    { value: 1, label: "Despesa" },
    { value: 2, label: "Receita" },
    { value: 3, label: "Ambas" },
  ];

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsSubmitting(true);

    const resultado = await cadastrarNovaCategoria(formData);
    try {
      if (resultado) {
        props.onSuccess();
      }
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="modal-form">
      <Input
        label="Nome da Categoria"
        placeholder="Ex: Salário ou Lazer"
        required
        value={formData.nome}
        onChange={(val) => setFormData({ ...formData, nome: val })}
      />

      <Select
        label="Finalidade"
        required
        options={finalidadeOptions}
        value={formData.finalidade}
        onChange={(val) =>
          setFormData({ ...formData, finalidade: parseInt(val) || 0 })
        }
      />

      <div className="form-actions">
        <Button
          descricao={isSubmitting ? "Salvando..." : "Cadastrar Categoria"}
          className="button-save"
          typeButton="submit"
        />
      </div>
    </form>
  );
}
