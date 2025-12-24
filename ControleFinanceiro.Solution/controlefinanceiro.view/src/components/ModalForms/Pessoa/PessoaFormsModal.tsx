import { useState } from "react";
import { type PessoaCriarDTO } from "../../../types/baseTypes/Pessoa";
import { cadastrarNovaPessoa } from "../../../services/pessoaServices";
import Button from "../../Button/Button";
import Input from "../../Input/Input";
import "./style.css";

export default function PessoaForm(props: { onSuccess: () => void }) {
  const [formData, setFormData] = useState<PessoaCriarDTO>({
    nome: "",
    idade: 0,
  });
  const [isSubmitting, setIsSubmitting] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsSubmitting(true);

    try {
      const resultado = await cadastrarNovaPessoa(formData);
      if (resultado) {
        props.onSuccess();
      }
    } catch (error) {
      alert("Erro ao cadastrar pessoa.");
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="modal-form">
      <Input
        label="Nome"
        placeholder="Ex: Pedro Assenção"
        required
        value={formData.nome}
        onChange={(val) => setFormData({ ...formData, nome: val })}
      />

      <Input
        label="Idade"
        type="number"
        placeholder="Ex: 21"
        required
        value={formData.idade || ""}
        allowNegative={false}
        onChange={(val) =>
          setFormData({ ...formData, idade: parseInt(val) || 0 })
        }
      />

      <div className="form-actions">
        <Button
          descricao={isSubmitting ? "Salvando..." : "Cadastrar"}
          className="button-save"
          typeButton="submit"
        />
      </div>
    </form>
  );
}
