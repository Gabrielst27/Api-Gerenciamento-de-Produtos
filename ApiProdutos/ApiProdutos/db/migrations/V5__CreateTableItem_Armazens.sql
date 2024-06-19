CREATE SEQUENCE IF NOT EXISTS public.item_armazens_amzprod_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.item_armazens
(
    amzprod_id bigint NOT NULL DEFAULT nextval('item_armazens_amzprod_id_seq'::regclass),
    amzprod_quant integer NOT NULL,
    amzprod_amz_id bigint NOT NULL,
    amzprod_prod_id bigint NOT NULL,
    CONSTRAINT amzprod_id_pkey PRIMARY KEY (amzprod_id),
    CONSTRAINT item_armazens_amzprod_prod_id_fkey FOREIGN KEY (amzprod_prod_id)
        REFERENCES public.produtos (prod_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT item_armazens_amzprod_amz_id_fkey FOREIGN KEY (amzprod_amz_id)
        REFERENCES public.armazens (amz_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)