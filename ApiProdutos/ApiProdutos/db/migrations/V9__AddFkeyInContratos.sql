ALTER TABLE IF EXISTS public.contratos
ADD COLUMN contr_emp_id BIGINT NOT NULL;

ALTER TABLE public.contratos
ADD CONSTRAINT contratos_contr_emp_id_fkey FOREIGN KEY (contr_emp_id)
REFERENCES fornecedores (fornec_id)
ON UPDATE NO ACTION
ON DELETE NO ACTION;