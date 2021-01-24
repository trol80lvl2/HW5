CREATEPROCEDURE test()
LANGUAGE 'sql'
AS $$
CALL sp_insert_user('ANTON','TOHA');
CALL sp_insert_user('Roman','Holub');
CALL sp_insert_note('a433a56d-78b9-4f5b-bc0b-68bc9d4aa8a2','header','body',1);
CALL sp_insert_note('ae6ce587-f031-408c-a989-0fc4ec74a521','something good','bodyfull spirit',2);
CALL sp_select_note('ae6ce587-f031-408c-a989-0fc4ec74a521');
CALL sp_select_note('a433a56d-78b9-4f5b-bc0b-68bc9d4aa8a2');
call sp_select_user_notes('a433a56d-78b9-4f5b-bc0b-68bc9d4aa8a2');
CALL sp_select_user_notes('ae6ce587-f031-408c-a989-0fc4ec74a521');
CALL sp_select_users_notes_count();
CALL sp_select_users_notes_count();
CALL sp_update_note_mark_deleted('ae6ce587-f031-408c-a989-0fc4ec74a521');
CALL sp_update_note_mark_deleted('a433a56d-78b9-4f5b-bc0b-68bc9d4aa8a2');
$$;