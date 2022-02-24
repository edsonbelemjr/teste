$form = new \API\Entities\Echo();
$form->setMessage("Pepita teste!");
try {
    $pet = $client->echo()->post($form);
} catch (UnprocessableEntityException $e) {
    var_dump($e->getErrors());
}
