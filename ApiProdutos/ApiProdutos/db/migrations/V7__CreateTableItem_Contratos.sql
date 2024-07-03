CREATE SEQUENCE IF NOT EXISTS public.item_contratos_contrprod_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.item_contratos
(
    contrprod_id bigint NOT NULL DEFAULT nextval('item_contratos_contrprod_id_seq'::regclass),
    contrprod_quant integer NOT NULL,
    contrprod_contr_id bigint NOT NULL,
    contrprod_prod_id bigint NOT NULL,
    CONSTRAINT item_contratos_pkey PRIMARY KEY (contrprod_id),
    CONSTRAINT item_contratos_contrprod_prod_id_fkey FOREIGN KEY (contrprod_prod_id)
        REFERENCES public.produtos (prod_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT item_contratos_contrprod_contr_id_fkey FOREIGN KEY (contrprod_contr_id)
        REFERENCES public.contratos (contr_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)